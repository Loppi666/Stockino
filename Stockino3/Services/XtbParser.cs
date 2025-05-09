using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace Stockino3.Services;

public class XtbParser
{
    private readonly TransactionContext transactionContext;
    private static readonly HttpClient httpClient = new();

    public XtbParser(TransactionContext transactionContext)
    {
        this.transactionContext = transactionContext;
    }

    public async Task ParseXtb(string csvFile)
    {
        var transactions = await ParseXlsx(csvFile, "OPEN POSITION 04032025");

        try
        {
            await using var db = transactionContext;
            await db.Database.EnsureCreatedAsync();
            db.Transactions.AddRange(transactions);

            // Get existing products and transactions
            var existingProducts = await db.Products
                                           .Include(p => p.Transactions)
                                           .Where(p => transactions.Select(t => t.Product.Symbol).Contains(p.Symbol))
                                           .ToListAsync();

            // Filter out transactions that already exist in the database
            var newTransactions = transactions
                                 .Where(t => !existingProducts.Any(ep =>
                                                                       ep.Symbol == t.Product.Symbol &&
                                                                       ep.Transactions.Any(et => et.ExecutionTime == t.ExecutionTime)))
                                 .ToList();

            if (newTransactions.Any())
            {
                db.Transactions.AddRange(newTransactions);
                await db.SaveChangesAsync();
                Console.WriteLine($"Added {newTransactions.Count} new transactions to the database.");
            }
            else
            {
                Console.WriteLine("No new transactions to add.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<List<TransactionEntity>> ParseXlsx(string filePath, string sheetName)
    {
        var transactions = new List<TransactionEntity>();

        using var workbook = new XLWorkbook(filePath);

        // Find worksheets with names containing "open position" or "close position"
        var openPositionSheet = workbook.Worksheets.FirstOrDefault(ws =>
                                                                       ws.Name.Contains("OPEN POSITION", StringComparison.OrdinalIgnoreCase));
        var closePositionSheet = workbook.Worksheets.FirstOrDefault(ws =>
                                                                        ws.Name.Contains("CLOSED POSITION", StringComparison.OrdinalIgnoreCase));

        // Use open position sheet if available, otherwise use the first available worksheet
        var worksheet = openPositionSheet ?? workbook.Worksheets.FirstOrDefault();

        if (worksheet == null) return transactions;

        int rowCount = worksheet.LastRowUsed().RowNumber() - 1;
        for (int row = 12; row <= rowCount; row++) // Assuming first row is headers
        {
            string symbol = worksheet.Cell(row, 3).GetString();
            string name = worksheet.Cell(row, 3).GetString();

            // Get or create product from database
            var product = await GetOrCreateProduct(symbol, name, null, null);

            var transaction = new TransactionEntity()
            {
                ProductId = product.Id,
                Product = product,
                OperationType = OperationType.OPEN,
                Volume = double.TryParse(worksheet.Cell(row, 5).GetString(), out double volume)
                    ? volume
                    : default(double),
                ExecutionTime = DateTime.Parse(worksheet.Cell(row, 6).GetString()),
                Price = double.TryParse(worksheet.Cell(row, 7).GetString(), out double price) ? price : default(double),
                Margin =
                    double.TryParse(worksheet.Cell(row, 8).GetString(), out double margin) ? margin : (double?)null,
                Commission = double.TryParse(worksheet.Cell(row, 9).GetString(), out double commission)
                    ? commission
                    : (double?)null,
                Swap = double.TryParse(worksheet.Cell(row, 10).GetString(), out double swap) ? swap : (double?)null,
                GrossPL = double.TryParse(worksheet.Cell(row, 11).GetString(), out double grossPL)
                    ? grossPL
                    : (double?)null
            };
            transactions.Add(transaction);
        }

        worksheet = closePositionSheet ?? workbook.Worksheets.FirstOrDefault();

        if (worksheet == null) return transactions;

        rowCount = worksheet.LastRowUsed().RowNumber() - 1;
        for (int row = 14; row <= rowCount; row++) // Assuming first row is headers
        {
            string symbol = worksheet.Cell(row, 3).GetString();
            string name = worksheet.Cell(row, 3).GetString();

            // Get or create product from database
            var product = await GetOrCreateProduct(symbol, name, null, null);

            var transaction = new TransactionEntity()
            {
                ProductId = product.Id,
                Product = product,
                OperationType = OperationType.OPEN,
                Volume = double.TryParse(worksheet.Cell(row, 5).GetString(), out double volume)
                    ? volume
                    : default(double),
                ExecutionTime = DateTime.Parse(worksheet.Cell(row, 6).GetString()),
                Price = double.TryParse(worksheet.Cell(row, 7).GetString(), out double price) ? price : default(double),
                Margin =
                    double.TryParse(worksheet.Cell(row, 8).GetString(), out double margin) ? margin : (double?)null,
                Commission = double.TryParse(worksheet.Cell(row, 9).GetString(), out double commission)
                    ? commission
                    : (double?)null,
                Swap = double.TryParse(worksheet.Cell(row, 10).GetString(), out double swap) ? swap : (double?)null,
                GrossPL = double.TryParse(worksheet.Cell(row, 11).GetString(), out double grossPL)
                    ? grossPL
                    : (double?)null
            };
            transactions.Add(transaction);
        }

        return transactions;
    }

    private async Task<ProductEntity> GetOrCreateProduct(string symbol, string name, string isin, string echange)
    {
        var product = await transactionContext.Products
                                              .FirstOrDefaultAsync(p => p.Symbol == symbol);

        if (product == null)
        {
            product = new ProductEntity
            {
                Symbol = symbol,
                Name = name,
                ISIN = isin
            };

            // If we have an ISIN or name, try to enrich with data from Polygon.io API
            if (!string.IsNullOrEmpty(isin) || !string.IsNullOrEmpty(name))
            {
                try
                {
                    var result = await GetTickerFromIsin(isin, echange);
                    AlphaData.alphaVantageData.TryGetValue(echange, out var alphaVantageData);

                    product.Ticker = result.ticker + alphaVantageData.Suffix;


                    product.Currency = alphaVantageData.Currency;

                    /*// Polygon.io API key - replace with your actual key
                    const string polygonApiKey = "4YBYKpBOeQeUkHEL2YoKsCcfl7HHYWp5";


                    using var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {polygonApiKey}");
                    // Define search term - prefer ISIN if available, otherwise use name
                    var searchTerm = !string.IsNullOrEmpty(isin) ? isin : name;



    string url = $"https://api.polygon.io/v3/reference/tickers?iso_isin={isin}&apiKey={polygonApiKey}";
               HttpResponseMessage response = await client.GetAsync(url);
               string json = await response.Content.ReadAsStringAsync();

               JObject data = JObject.Parse(json);
                data["results"]?[0]?["ticker"]?.ToString();*/

                    // Find best match (prioritize USD or EUR currencies)
                    /*var bestMatch = searchResult?.Results?
                        .Where(r => r.Currency == "USD" || r.Currency == "EUR")
                        .OrderByDescending(r => r.Market == "stocks" ? 100 : 0) // Prefer stocks
                        .FirstOrDefault();

                    if (bestMatch != null)
                    {
                        product.Ticker = bestMatch.Ticker;
                        product.Currency = bestMatch.Currency;

                        // If name is empty, use the name from Polygon
                        if (string.IsNullOrEmpty(product.Name))
                        {
                            product.Name = bestMatch.Name;
                        }
                    }
                    else
                    {
                        product.Ticker = string.Empty;
                        product.Currency = string.Empty;
                    }*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error enriching product data: {ex.Message}");
                    product.Ticker = string.Empty;
                    product.Currency = string.Empty;
                }
            }

            transactionContext.Products.Add(product);
            await transactionContext.SaveChangesAsync();
        }

        return product;
    }

    private static async Task<(string ticker, string currency)> GetTickerFromIsin(string isin, string exchange)
    {
        try
        {
            var requestBody = new[]
            {
                new { idType = "ID_ISIN", idValue = isin }
            };
            var requestJson = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("X-OPENFIGI-APIKEY", "a08356ad-0452-4313-89b4-226e9906b9a4");

            var response = await httpClient.PostAsync("https://api.openfigi.com/v3/mapping", content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            using var jsonDoc = JsonDocument.Parse(responseJson);
            var root = jsonDoc.RootElement;

            if (root.GetArrayLength() == 0 || !root[0].TryGetProperty("data", out var dataArray) ||
                dataArray.GetArrayLength() == 0)
            {
                return ("No ticker found", "");
            }

            var dataObject = dataArray[0];
            var ticker = dataObject.TryGetProperty("ticker", out var tickerElement)
                ? tickerElement.GetString()
                : "Unknown";

            var currency = dataObject.TryGetProperty("currencyCode", out var currencyElement)
                ? currencyElement.GetString()
                : "";

            return (ticker, currency);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching ticker for ISIN {isin} on {exchange}: {ex.Message}");
            return ("Error", "");
        }
    }
}
