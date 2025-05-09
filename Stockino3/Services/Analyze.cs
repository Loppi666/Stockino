using System.Globalization;
using System.Text;
using System.Text.Json;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.Client;
using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;


namespace Stockino3.Services;

public class Analyze
{
    private readonly TransactionContext transactionContext;

    public Analyze(TransactionContext transactionContext)
    {
        this.transactionContext = transactionContext;
    }

    private const string ApiKey = "9E71JJDSQDAD5CZR";

    private static readonly HttpClient httpClient = new();


    public async Task PerformeAnalyze(string csvFile)
    {
        

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            HasHeaderRecord = true,
            MissingFieldFound = null
        };

        List<TransactionEntity> transactions;
        try
        {
            using var reader = new StreamReader(csvFile);
            using var csv = new CsvReader(reader, config);
            csv.Read();
            csv.ReadHeader();
            // Get existing products and transactions
            var transactionModels = csv.GetRecords<TransactionCsvModel>()
                .Where(x => !x.ISIN.IsNullOrEmpty())
                .ToList();

            var uniqueProducts = transactionModels
                .Where(x => !string.IsNullOrEmpty(x.ISIN) && !string.IsNullOrEmpty(x.Exchange))
                .GroupBy(x => new { x.ISIN, x.Exchange })
                .Select(g => g.First())
                .ToList();

// Pre-load all products to avoid creating duplicates
            foreach (var model in uniqueProducts)
            {
                await GetOrCreateProduct(model.ISIN, model.Product, model.ISIN, model.Exchange);
            }


            transactions = new List<TransactionEntity>();
            foreach (var model in transactionModels)
            {
                transactions.Add(await MapCsvToEntity(model));
            }


            // Get existing transactions from database
            var existingTransactions = await transactionContext.Transactions
                .ToListAsync();

// Filter out transactions that already exist by checking key transaction properties
            var newTransactions = transactions
                .Where(t => !existingTransactions.Any(et =>
                    et.ProductId == t.ProductId &&
                    et.ExecutionTime == t.ExecutionTime &&
                    et.OperationType == t.OperationType &&
                    Math.Abs(et.Volume - t.Volume) < 0.001 &&
                    Math.Abs(et.Price - t.Price) < 0.001))
                .ToList();

            if (newTransactions.Any())
            {
                transactionContext.Transactions.AddRange(newTransactions);
                await transactionContext.SaveChangesAsync();
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


    private async Task<TransactionEntity> MapCsvToEntity(TransactionCsvModel csvModel)
    {
        // Parse the date and time
        DateTime executionTime;
        if (!string.IsNullOrEmpty(csvModel.Time))
        {
            // If time is available, combine with date
            executionTime = DateTime.ParseExact(
                $"{csvModel.DateString} {csvModel.Time}",
                "dd-MM-yyyy HH:mm",
                CultureInfo.InvariantCulture);
        }
        else
        {
            // If only date is available
            executionTime = csvModel.Date;
        }

        // Determine operation type based on quantity (negative is CLOSE/sell, positive is OPEN/buy)
        var operationType = csvModel.Quantity < 0 ? OperationType.CLOSE : OperationType.OPEN;

        // Get or create the product
        var symbol = csvModel.ISIN ?? csvModel.Product;
        var product = await GetOrCreateProduct(symbol, csvModel.Product, csvModel.ISIN, csvModel.Exchange);


        return new TransactionEntity
        {
            ProductId = product.Id,
            OperationType = operationType,
            Volume = Math.Abs(csvModel.Quantity), // Use absolute value for volume
            ExecutionTime = executionTime,
            Price = csvModel.Price,
            Currency = csvModel.TotalCurreny,
            // Other fields don't have direct mappings in CSV, so leaving as null
            Margin = null,
            Commission = null,
            Swap = null,
            GrossPL = null
        };
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


    // Polygon.io response models
    public class PolygonSearchResponse
    {
        public List<PolygonTickerResult> Results { get; set; }
    }

    public class PolygonTickerResult
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Market { get; set; }
    }
}

public enum OperationType
{
    OPEN,
    CLOSE
}

class TransactionCsvModel
{
    [Name("Datum")] public string DateString { get; set; }
    public DateTime Date => DateTime.ParseExact(DateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);

    [Name("Čas")] public string Time { get; set; }

    [Name("Produkt")] public string Product { get; set; }

    [Name("ISIN")] public string ISIN { get; set; }

    [Name("Reference")] public string Reference { get; set; }

    [Name("Venue")] public string Exchange { get; set; }

    [Name("Počet")] public string QuantityString { get; set; }
    public int Quantity => int.TryParse(QuantityString, out int value) ? value : 0;

    [Name("Cena")] public string PriceString { get; set; }

    public double Price =>
        double.TryParse(PriceString.Split(',')[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double value)
            ? value
            : 0;

    [Name("Hodnota v domácí měně")] public string LocalValueString { get; set; }

    public double LocalValue => double.TryParse(LocalValueString.Split(',')[0], NumberStyles.Any,
        CultureInfo.InvariantCulture, out double value)
        ? value
        : 0;

    [Name("Hodnota")] public string ValueString { get; set; }

    public double Value =>
        double.TryParse(ValueString.Split(',')[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double value)
            ? value
            : 0;

    [CsvHelper.Configuration.Attributes.Index(13)]
    public string ValueCurreny { get; set; }

    [Name("Směnný kurz")] public string ExchangeRateString { get; set; }

    public double ExchangeRate =>
        double.TryParse(ExchangeRateString, NumberStyles.Any, CultureInfo.InvariantCulture, out double value)
            ? value
            : 1;


    [Name("Transaction and/or third")] public string TransactionFeeString { get; set; }

    public double TransactionFee => double.TryParse(TransactionFeeString.Split(',')[0], NumberStyles.Any,
        CultureInfo.InvariantCulture, out double value)
        ? Math.Abs(value)
        : 0;

    [CsvHelper.Configuration.Attributes.Index(15)]
    public string TransactionFeeCurreny { get; set; }


    [Name("Celkem")] public string TotalString { get; set; }

    public double Total =>
        double.TryParse(TotalString.Split(',')[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double value)
            ? value
            : 0;

    [CsvHelper.Configuration.Attributes.Index(18)]
    public string TotalCurreny { get; set; }
}

public class TransactionContext(DbContextOptions<TransactionContext> options) : DbContext(options)
{
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransactionEntity>()
            .HasOne(t => t.Product)
            .WithMany(p => p.Transactions)
            .HasForeignKey(t => t.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}
