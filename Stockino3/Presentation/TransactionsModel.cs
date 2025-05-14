using System.Globalization;
using System.Text.Json;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI;
using Stockino3.Services;

namespace Stockino3.Presentation;

// DTO pro předávání součtů portfolia
public record PortfolioSumsDto(ProductEntity Product, string Currency, decimal TotalPrice, decimal TotalVolume, decimal TaxFreeVolume);

public class TransactionsModel : IService
{
    // Vlastnosti pro indikátor trendu
    public string TrendSymbol { get; private set; }
    public SolidColorBrush TrendColor { get; private set; }
    public string TrendDirection { get; private set; }
    private readonly TransactionContext _transactionContext;
    private readonly IAlphaVantageApi _alphaVantageApi;

    public TransactionsModel(TransactionContext transactionContext, IAlphaVantageApi alphaVantageApi)
    {
        _transactionContext = transactionContext;
        _alphaVantageApi = alphaVantageApi;

        // Nastavení výchozího trendu
        UpdateTrendIndicator();
    }

    public void UpdateTrendIndicator()
    {
        // Zde můžete implementovat logiku pro určení trendu na základě dat
        // Momentálně používám zjednodušený přístup s pevně daným trendem
        string trend = "up"; // Toto by mělo být nahrazeno skutečným zdrojem dat nebo výpočtem

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

    public IFeed<List<TransactionViewModel>> Transactions => Feed.Async(async ct => await LoadTransactionsAsync());

    public async ValueTask DoWork()
    {
        await ValueTask.CompletedTask;
    }

    public async Task<List<TransactionViewModel>> LoadTransactionsAsync()
    {
        var data = await GetPortfolioSumsAsync();
        var viewModels = new List<TransactionViewModel>();

        foreach (var portfolioSum in data)
        {
            if (portfolioSum.TotalVolume > 0)
            {
                var product = portfolioSum.Product;
                string description = product?.Name ?? product?.Symbol ?? "Neznámý produkt";
                decimal shares = portfolioSum.TotalVolume;
                decimal avgPrice = shares != 0 ? portfolioSum.TotalPrice / shares : 0;
                decimal taxFreeShares = portfolioSum.TaxFreeVolume;

                decimal price = await GetStockPrices(product.Ticker, product.ISIN);

                // Přepočet na měnu nákupu, pokud se liší měny
                decimal convertedPrice = price;
                decimal exchangeRate = 1;
                string displayCurrency = portfolioSum.Currency;

                if (!string.IsNullOrEmpty(product.Currency) && !string.IsNullOrEmpty(portfolioSum.Currency) &&
                    !string.Equals(product.Currency, portfolioSum.Currency, StringComparison.OrdinalIgnoreCase))
                {
                    exchangeRate = await GetExchangeRateAsync(product.Currency, portfolioSum.Currency);
                    convertedPrice = price * exchangeRate;
                    displayCurrency = portfolioSum.Currency;
                }

                decimal totalAmount = shares * convertedPrice;
                decimal absoluteProfit = (convertedPrice - avgPrice) * shares;
                decimal profitPercentage = avgPrice > 0 ? (convertedPrice - avgPrice) / avgPrice * 100 : 0;
                decimal taxFreeAmount = taxFreeShares * convertedPrice;

                viewModels.Add(new TransactionViewModel
                {
                    Description = description,
                    Reference = $"Shares: {shares}",
                    Amount = $"Avg: {avgPrice:F2} {displayCurrency}",
                    Volume = $"Množství: {shares}, po časovém testu {taxFreeShares}",
                    TaxFreeVolume = taxFreeShares,
                    TaxFreeAmount = taxFreeAmount,
                    TotalAmount = $"{totalAmount:F2} {displayCurrency}, (za jednotku: {convertedPrice:F2}), průměrná cena: {avgPrice:F2}",
                    TotalAmountDecimal = totalAmount,
                    Ticker = product.Ticker,
                    AvgPrice = avgPrice,
                    CurrentPrice = convertedPrice
                });
            }
        }

        return viewModels.OrderBy(x => x.Description).ToList();
    }

    public const string AlphaApiKey = "9E71JJDSQDAD5CZR";

    private async Task<decimal> GetStockPrices(string ticker, string isin)
    {
        if (string.IsNullOrEmpty(ticker))
        {
            return decimal.Zero;
        }

        decimal price = 0;

        try
        {
            // Use AlphaVantage NuGet package
            using var alphavantageClient = new AlphaVantageClient(AlphaApiKey);
            var stocksClient = alphavantageClient.Stocks();

            var quote = await stocksClient.GetGlobalQuoteAsync(ticker);
            price = quote.Price;
        }
        catch (Exception ex)
        {
            try
            {
                using var httpClient = new HttpClient();
                string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{ticker}";

                string response = await httpClient.GetStringAsync(url);
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
    private static readonly Dictionary<string, (decimal Rate, DateTime Timestamp)> _exchangeRateCache = new();
    private static readonly TimeSpan _cacheDuration = TimeSpan.FromHours(24); // Cache for 24 hours

    private async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
    {
        try
        {
            string cacheKey = $"{fromCurrency}_{toCurrency}";

            // Check if we have a valid cached rate
            if (_exchangeRateCache.TryGetValue(cacheKey, out var cachedRate) &&
                ((DateTime.Now - cachedRate.Timestamp) < _cacheDuration))
            {
                return cachedRate.Rate;
            }

            // Získání kurzu přes refit klienta bez zadávání apiKey
            var response = await _alphaVantageApi.GetExchangeRateAsync(fromCurrency, toCurrency);

            decimal rate = 1;

            if (response?.RealtimeCurrencyExchangeRate?.ExchangeRate != null)
            {
                rate = decimal.Parse(response.RealtimeCurrencyExchangeRate.ExchangeRate, CultureInfo.InvariantCulture);
            }

            _exchangeRateCache[cacheKey] = (rate, DateTime.Now);

            return rate;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting exchange rate from {fromCurrency} to {toCurrency}: {ex.Message}");

            return 1; // Default to 1:1 exchange rate on error
        }
    }

    // Vrací seznam souhrnů podle produktu, mapovaných rovnou do DTO
    public async Task<List<PortfolioSumsDto>> GetPortfolioSumsAsync()
    {
        var threeYearsAgo = DateTime.Now.AddYears(-3);

            var sums = await _transactionContext.Transactions
                                                .Include(t => t.Product)
                                                .GroupBy(t => new
                                                 {
                                                     t.ProductId,
                                                     t.BuyInCurrency
                                                 })
                                                .Select(g => new PortfolioSumsDto(  g.First().Product,
                                                                                  g.Key.BuyInCurrency,
                                                                                
                                                                                  g.Sum(t => t.OperationType == OperationType.OPEN
                                                                                            ? t.TotalCost
                                                                                            : -t.TotalCost),
                                                                                  g.Sum(t => t.OperationType == OperationType.OPEN
                                                                                            ? t.Volume
                                                                                            : -t.Volume),
                                                                                  g.Sum(t => (t.OperationType == OperationType.OPEN) && (t.ExecutionTime <= threeYearsAgo)
                                                                                            ? t.Volume
                                                                                            : 0)))
                                                .AsSplitQuery()
                                                .ToListAsync();
            
            return sums;

        
    }
}
