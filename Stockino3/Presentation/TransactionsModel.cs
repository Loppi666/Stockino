using System.Collections.ObjectModel;
using System.Text.Json;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI;
using Stockino3.Services;
using Uno.Extensions.Reactive;

namespace Stockino3.Presentation;

public class TransactionsModel
{
    // Vlastnosti pro indikátor trendu
    public string TrendSymbol { get; private set; }
    public SolidColorBrush TrendColor { get; private set; }
    public string TrendDirection { get; private set; }
    private readonly TransactionContext _transactionContext;

    public TransactionsModel(TransactionContext transactionContext)
    {
        _transactionContext = transactionContext;

        // Nastavení výchozího trendu
        UpdateTrendIndicator();
    }

    public void UpdateTrendIndicator()
    {
        // Zde můžete implementovat logiku pro určení trendu na základě dat
        // Momentálně používám zjednodušený přístup s pevně daným trendem
        var trend = "up"; // Toto by mělo být nahrazeno skutečným zdrojem dat nebo výpočtem

        if (trend.ToLower() == "up")
        {
            // Rostoucí trend - zelený
            TrendColor = new SolidColorBrush(Colors.ForestGreen);
            TrendSymbol = "📈";
            TrendDirection = "Rostoucí";
        }
        else if (trend.ToLower() == "down")
        {
            // Klesající trend - červený
            TrendColor = new SolidColorBrush(Colors.Crimson);
            TrendSymbol = "📉";
            TrendDirection = "Klesající";
        }
        else
        {
            // Neutrální trend - šedý
            TrendColor = new SolidColorBrush(Colors.DimGray);
            TrendSymbol = "📊";
            TrendDirection = "Stabilní";
        }
    }

    public IFeed<List<TransactionViewModel>> Transactions => Feed.Async(async ct => await this.LoadTransactionsAsync());

    public async ValueTask DoWork()
    {
        await ValueTask.CompletedTask;
    }

    // In your data loading method:

    public async Task<List<TransactionViewModel>> LoadTransactionsAsync()
    {
        List<TransactionEntity> transactions = new List<TransactionEntity>();
        
        try
        {
             transactions = await _transactionContext.Transactions
                                                        .Include(t => t.Product)
                                                        .ToListAsync();
        }
        catch (Exception e)
        {
            
            
        }

        // Calculate portfolio state
        var portfolio =
            new Dictionary<ProductEntity, (decimal Shares, decimal TaxFreeShares, decimal AvgPrice
                )>();

        var today = DateTime.Now;
        var threeYearsAgo = today.AddYears(-3);

        foreach (var transaction in transactions.OrderBy(t => t.ExecutionTime))
        {
            string symbol = transaction.Product.Symbol;
            string ticker = transaction.Product.Ticker;

            if (!portfolio.ContainsKey((transaction.Product)))
                portfolio[(transaction.Product)] = (0, 0, 0);

            var (currentShares, currentTaxFreeShares, currentAvgPrice) = portfolio[(transaction.Product)];

            if (transaction.OperationType == OperationType.OPEN)
            {
                // Buy operation
                decimal newShares = currentShares + (decimal)transaction.Volume;
                decimal newTaxFreeShares = currentTaxFreeShares;

                // For buys older than 3 years, add to tax-free shares
                if (transaction.ExecutionTime <= threeYearsAgo)
                {
                    newTaxFreeShares += (decimal)transaction.Volume;
                }

                // Správný výpočet váženého průměru
                decimal totalValueBefore = currentShares * currentAvgPrice;

                // Cena za kus = absolutní hodnota celkové ceny dělená objemem (Volume)
                decimal pricePerUnit = Math.Abs((decimal)transaction.Price) / (decimal)transaction.Volume;
                decimal newPurchaseValue = (decimal)transaction.Volume * pricePerUnit;

                decimal totalValueAfter = totalValueBefore + newPurchaseValue;

                decimal newAvgPrice = newShares > 0
                    ? totalValueAfter / newShares
                    : 0;

                portfolio[(transaction.Product)] = (newShares, newTaxFreeShares, newAvgPrice);
            }
            else
            {
                // Sell operation
                decimal newShares = currentShares - (decimal)transaction.Volume;

                // Reduce tax-free shares proportionally (FIFO principle)
                decimal taxFreeRatio = currentShares > 0
                    ? currentTaxFreeShares / currentShares
                    : 0;

                decimal newTaxFreeShares =
                    Math.Max(0, currentTaxFreeShares - ((decimal)transaction.Volume * taxFreeRatio));

                // Průměrná cena zůstává stejná při prodeji
                portfolio[(transaction.Product)] = (newShares, newTaxFreeShares, currentAvgPrice);
            }
        }

        var viewModels = new List<TransactionViewModel>();

        // Create portfolio summary items
        foreach (var (symbol, (shares, taxFreeShares, avgPrice)) in portfolio)
        {
            if (shares > 0)
            {
                // Find the product for this symbol to get more details
                var product = transactions.FirstOrDefault(t => t.Product.Symbol == symbol.Symbol)?.Product;
                string description = product?.Name ?? symbol.Symbol;
                var price = await GetStockPrices(symbol.Ticker, symbol.ISIN);
                var totalAmount = shares * price;

                decimal absoluteProfit = (price - avgPrice) * shares;

                decimal profitPercentage = avgPrice > 0
                    ? ((price - avgPrice) / avgPrice) * 100
                    : 0;

                decimal taxFreeAmount = taxFreeShares * price;

                viewModels.Add(new TransactionViewModel
                {
                    Description = description,
                    Reference = $"Shares: {shares}",
                    Amount = $"Avg: {avgPrice:F2} {product.Currency}",
                    Volume = $"Množství: {shares}, po časovém testu {taxFreeShares}",
                    TaxFreeVolume = taxFreeShares,
                    TaxFreeAmount = taxFreeAmount,
                    TotalAmount = $"{totalAmount:F2} {product.Currency}, (za jednotku: {price:F2})",
                    TotalAmountDecimal = totalAmount,
                    Ticker = product.Ticker,
                    AvgPrice = avgPrice,
                    CurrentPrice = price
                });
            }
        }

        
        // Load your transactions asynchronously
        return viewModels.OrderBy(x => x.Description).ToList();
    }

    public const string AlphaApiKey = "9E71JJDSQDAD5CZR";

    private async Task<decimal> GetStockPrices(string ticker, string isin)
    {
        if (string.IsNullOrEmpty(ticker))
            return decimal.Zero;

        decimal price = 0;

        try
        {
            // Use AlphaVantage NuGet package
            using var alphavantageClient = new AlphaVantageClient(AlphaApiKey);
            var stocksClient = alphavantageClient.Stocks();

            var quote = await stocksClient.GetGlobalQuoteAsync(ticker);
            price = (decimal)quote.Price;
        }
        catch (Exception ex)
        {
            try
            {
                using var httpClient = new HttpClient();
                string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{ticker}";

                var response = await httpClient.GetStringAsync(url);
                var jsonDocument = JsonDocument.Parse(response);

                price = decimal.Zero;
                var resultElement = jsonDocument.RootElement.GetProperty("chart").GetProperty("result")[0];

                if (resultElement.TryGetProperty("meta", out var metaElement) &&
                    metaElement.TryGetProperty("regularMarketPrice", out var priceElement))
                {
                    price = priceElement.GetDecimal();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /*
        // Use Polygon.io API instead of Alpha Vantage
        using var httpClient = new HttpClient();
        string url = $"https://query1.finance.yahoo.com/v8/finance/chart/EQQQ";

        var response = await httpClient.GetStringAsync(url);
        var jsonDocument = System.Text.Json.JsonDocument.Parse(response);


        decimal price = decimal.Zero;
        var resultElement = jsonDocument.RootElement.GetProperty("chart").GetProperty("result")[0];

        if (resultElement.TryGetProperty("meta", out var metaElement) &&
            metaElement.TryGetProperty("regularMarketPrice", out var priceElement))
        {
            price = priceElement.GetDecimal();
        }
        */

        // Get the currency from the product and convert if not in EUR
        // var product = await _transactionContext.Products
        //                                        .FirstOrDefaultAsync(p => p.Ticker == ticker || p.ISIN == isin);
        //
        // if (product != null && !string.IsNullOrEmpty(product.Currency) && product.Currency != "EUR")
        // {
        //     var exchangeRate = await GetExchangeRateAsync(product.Currency, "EUR");
        //
        //     // Convert to EUR
        //     price *= exchangeRate;
        // }

        return price;
    }

    // Static dictionary to cache exchange rates (fromCurrency_toCurrency -> (rate, timestamp))
    private static Dictionary<string, (decimal Rate, DateTime Timestamp)> _exchangeRateCache = new();
    private static readonly TimeSpan _cacheDuration = TimeSpan.FromHours(24); // Cache for 24 hours

    private async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
    {
        try
        {
            string cacheKey = $"{fromCurrency}_{toCurrency}";

            // Check if we have a valid cached rate
            if (_exchangeRateCache.TryGetValue(cacheKey, out var cachedRate) &&
                (DateTime.Now - cachedRate.Timestamp) < _cacheDuration)
            {
                return cachedRate.Rate;
            }

            // Not in cache or expired, fetch from API
            var url =
                $"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={fromCurrency}&to_currency={toCurrency}&apikey={AlphaApiKey}";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            var exchangeRateData = System.Text.Json.JsonDocument.Parse(response);

            var exchangeRateValue = exchangeRateData.RootElement
                                                    .GetProperty("Realtime Currency Exchange Rate")
                                                    .GetProperty("5. Exchange Rate")
                                                    .GetString();

            decimal rate = decimal.Parse(exchangeRateValue, System.Globalization.CultureInfo.InvariantCulture);

            // Store in cache
            _exchangeRateCache[cacheKey] = (rate, DateTime.Now);

            return rate;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting exchange rate from {fromCurrency} to {toCurrency}: {ex.Message}");

            return 1; // Default to 1:1 exchange rate on error
        }
    }
    
    
}
