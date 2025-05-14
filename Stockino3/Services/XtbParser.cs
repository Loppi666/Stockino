using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Refit;

// přidáno pro IAlphaVantageApi

namespace Stockino3.Services;

public class XtbParser : IService
{
    private readonly TransactionContext transactionContext;
    private static readonly HttpClient httpClient = new();
    private readonly ExchangeRateService exchangeRateService;
    private readonly IAlphaVantageApi alphaVantageApi; // přidáno

    public XtbParser(TransactionContext transactionContext, ExchangeRateService exchangeRateService, IAlphaVantageApi alphaVantageApi)
    {
        this.transactionContext = transactionContext;
        this.exchangeRateService = exchangeRateService;
        this.alphaVantageApi = alphaVantageApi; // přidáno
    }

    public async Task ParseXtb(string csvFile)
    {
        var transactions = await ParseXlsx(csvFile, "OPEN POSITION 04032025");

        try
        {
        
            await transactionContext.Database.EnsureCreatedAsync();
            transactionContext.Transactions.AddRange(transactions);

            // Get existing products and transactions
            var existingProducts = await transactionContext.Products
                                                           .Include(p => p.Transactions)
                                                           .Where(p => transactions.Select(t => t.Product.Symbol).Contains(p.Symbol))
                                                           .ToListAsync();

            // Filter out transactions that already exist in the database
            var newTransactions = transactions
                                 .Where(t =>
                                            !existingProducts.Any(ep =>
                                                                      (ep.Symbol == t.Product.Symbol) &&
                                                                      ep.Transactions.Any() && // produkt má nějaké transakce
                                                                      ep.Transactions.Any(et => et.ExecutionTime == t.ExecutionTime))
                                          ||
                                            !existingProducts.Any(ep =>
                                                                      (ep.Symbol == t.Product.Symbol) &&
                                                                      !ep.Transactions.Any() // produkt nemá žádné transakce
                                                                 ))
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

        if (worksheet == null)
        {
            return transactions;
        }

        // Najdi měnu v listu
        string currency = null; // Změna var na string a inicializace
        bool currencyFound = false;

        if (worksheet.LastCellUsed() != null) // Zkontrolujte, zda list není prázdný
        {
            for (int r = 1; r <= worksheet.LastRowUsed().RowNumber(); r++)
            {
                for (int c = 1; c <= worksheet.LastColumnUsed().ColumnNumber(); c++)
                {
                    string? cellValue = worksheet.Cell(r, c).GetString();

                    if (cellValue.Trim().Equals("currency", StringComparison.OrdinalIgnoreCase))
                    {
                        currency = worksheet.Cell(r + 1, c).GetString().Trim();
                        currencyFound = true;

                        break;
                    }
                }

                if (currencyFound)
                {
                    break;
                }
            }
        }

        int rowCount = worksheet.LastRowUsed().RowNumber() - 1;

        for (int row = 12; row <= rowCount; row++) // Assuming first row is headers
        {
            string symbol = worksheet.Cell(row, 3).GetString();
            string name = worksheet.Cell(row, 3).GetString();

            // Get or create product from database
            var product = await GetOrCreateProduct(symbol, name, null, currency);

            decimal.TryParse(worksheet.Cell(row, 5).GetString(), out decimal volume);
            decimal.TryParse(worksheet.Cell(row, 9).GetString(), out decimal totalPraiceInHome);

            decimal? pricePerUnitInHomeCurrency = (totalPraiceInHome > 0) && (volume > 0)
                ? totalPraiceInHome / volume
                : null;

            var executionTime = DateTime.Parse(worksheet.Cell(row, 6).GetString());

            double? exchangeRate = await exchangeRateService.GetHistoricalExchangeRateAsync(product.Currency, currency, executionTime.Date);

            decimal? pricePerUnitFundCurrency = pricePerUnitInHomeCurrency.HasValue && (exchangeRate > 0)
                ? pricePerUnitInHomeCurrency / (decimal)exchangeRate
                : null;

            var transaction = new TransactionEntity
            {
                ProductId = product.Id,
                Product = product,
                OperationType = OperationType.OPEN,
                Volume = volume,
                ExecutionTime = executionTime,
                UnitPrice = pricePerUnitFundCurrency ?? 0,
                TotalPrice = (pricePerUnitFundCurrency ?? 0) * volume,
                TotalCost = totalPraiceInHome,
                Margin =
                    decimal.TryParse(worksheet.Cell(row, 8).GetString(), out decimal margin)
                        ? margin
                        : null,
                Commission = decimal.TryParse(worksheet.Cell(row, 9).GetString(), out decimal commission)
                    ? commission
                    : null,
                Swap = decimal.TryParse(worksheet.Cell(row, 10).GetString(), out decimal swap)
                    ? swap
                    : null,
                GrossPL = decimal.TryParse(worksheet.Cell(row, 11).GetString(), out decimal grossPL)
                    ? grossPL
                    : null,
                BuyInCurrency = currency // pokud existuje property
            };

            transactions.Add(transaction);
        }

        worksheet = closePositionSheet ?? workbook.Worksheets.FirstOrDefault();

        if (worksheet == null)
        {
            return transactions;
        }

        // Najdi měnu i v tomto listu
        currency = null; // Reset pro nový list
        currencyFound = false; // Reset pro nový list

        if (worksheet.LastCellUsed() != null) // Zkontrolujte, zda list není prázdný
        {
            for (int r = 1; r <= worksheet.LastRowUsed().RowNumber(); r++)
            {
                for (int c = 1; c <= worksheet.LastColumnUsed().ColumnNumber(); c++)
                {
                    string? cellValue = worksheet.Cell(r, c).GetString();

                    if (cellValue.Trim().Equals("currency", StringComparison.OrdinalIgnoreCase))
                    {
                        currency = worksheet.Cell(r + 1, c).GetString().Trim();
                        currencyFound = true;

                        break;
                    }
                }

                if (currencyFound)
                {
                    break;
                }
            }
        }

        rowCount = worksheet.LastRowUsed().RowNumber() - 1;

        for (int row = 14; row <= rowCount; row++) // Assuming first row is headers
        {
            string symbol = worksheet.Cell(row, 3).GetString();
            string name = worksheet.Cell(row, 3).GetString();

            // Get or create product from database
            var product = await GetOrCreateProduct(symbol, name, null, currency);

            var transaction = new TransactionEntity
            {
                ProductId = product.Id,
                Product = product,
                OperationType = OperationType.CLOSE,
                Volume = decimal.TryParse(worksheet.Cell(row, 5).GetString(), out decimal volume)
                    ? volume
                    : default,
                ExecutionTime = DateTime.Parse(worksheet.Cell(row, 6).GetString()),
                UnitPrice = decimal.TryParse(worksheet.Cell(row, 7).GetString(), out decimal price)
                    ? price
                    : default,
                Margin =
                    decimal.TryParse(worksheet.Cell(row, 8).GetString(), out decimal margin)
                        ? margin
                        : null,
                Commission = decimal.TryParse(worksheet.Cell(row, 9).GetString(), out decimal commission)
                    ? commission
                    : null,
                Swap = decimal.TryParse(worksheet.Cell(row, 10).GetString(), out decimal swap)
                    ? swap
                    : null,
                GrossPL = decimal.TryParse(worksheet.Cell(row, 11).GetString(), out decimal grossPL)
                    ? grossPL
                    : null,
                BuyInCurrency = product.Currency // pokud existuje property
            };

            transactions.Add(transaction);
        }

        return transactions;
    }

    private async Task<ProductEntity?> GetOrCreateProduct(string symbol, string name, string isin, string currency)
    {
        var product = await transactionContext.Products
                                        .FirstOrDefaultAsync(p => p.ProviderIdentificator == symbol);

        if (product == null)
        {
            var figiData = await GetInstrumentDetailsAsync(symbol);

            if (figiData is null)
            {
                return null;
            }

            string ticker = figiData.Ticker + OpenFigiToAlphaVantageMapper.GetAlphaVantageSuffix(figiData.ExchCode);

            var ss = await GetSymbolOverviewONalphaAsync(ticker);

            product = new ProductEntity
            {
                Symbol = symbol,
                Name = figiData.Name,
                ISIN = isin,
                Ticker = ss.Symbol,
                Currency = ss.Currency,
                ProviderIdentificator = symbol
            };

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
                new
                {
                    idType = "ID_ISIN",
                    idValue = isin
                }
            };

            string requestJson = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("X-OPENFIGI-APIKEY", "a08356ad-0452-4313-89b4-226e9906b9a4");

            var response = await httpClient.PostAsync("https://api.openfigi.com/v3/mapping", content);
            response.EnsureSuccessStatusCode();
            string responseJson = await response.Content.ReadAsStringAsync();

            using var jsonDoc = JsonDocument.Parse(responseJson);
            var root = jsonDoc.RootElement;

            if ((root.GetArrayLength() == 0) || !root[0].TryGetProperty("data", out var dataArray) ||
                (dataArray.GetArrayLength() == 0))
            {
                return ("No ticker found", "");
            }

            var dataObject = dataArray[0];

            string? ticker = dataObject.TryGetProperty("ticker", out var tickerElement)
                ? tickerElement.GetString()
                : "Unknown";

            string? currency = dataObject.TryGetProperty("currencyCode", out var currencyElement)
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

    public async Task<string> GetSymbolOverviewAsync(string symbol)
    {
        try
        {
            var overviewData = await alphaVantageApi.GetOverviewAsync(symbol);

            if ((overviewData != null) && !string.IsNullOrEmpty(overviewData.Symbol))
            {
                Console.WriteLine($"\nDetaily pro symbol: {overviewData.Symbol}");
                Console.WriteLine($"  Název: {overviewData.Name}");
                Console.WriteLine($"  Popis: {overviewData.Description}");
                Console.WriteLine($"  Typ aktiva: {overviewData.AssetType}");
                Console.WriteLine($"  Burza: {overviewData.Exchange}");
                Console.WriteLine($"  Měna: {overviewData.Currency}");

                if ((overviewData.Description != null) && overviewData.Description.ToLower().Contains("treasury bond"))
                {
                    Console.WriteLine("  Potvrzeno: Popis obsahuje 'Treasury Bond'.");
                }
            }
            else
            {
                Console.WriteLine($"Pro '{symbol}' nebyly nalezeny žádné detaily nebo nastala chyba při parsování odpovědi.");
            }

            return overviewData?.Symbol;
        }
        catch (ApiException apiEx)
        {
            Console.WriteLine($"Chyba API při získávání detailů pro '{symbol}': {apiEx.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Neznámá chyba pro '{symbol}': {e.Message}");
        }

        return null;
    }

    public async Task<SymbolSearchMatch?> GetSymbolOverviewONalphaAsync(string symbol)
    {
        try
        {
            var searchResult = await alphaVantageApi.SearchSymbolAsync(symbol);

            if ((searchResult != null) && (searchResult.BestMatches != null) && searchResult.BestMatches.Any())
            {
                var bestMatch = searchResult.BestMatches.First();

                Console.WriteLine($"\nDetaily pro symbol: {bestMatch.Symbol}");
                Console.WriteLine($"  Název: {bestMatch.Name}");
                Console.WriteLine($"  Typ: {bestMatch.Type}");
                Console.WriteLine($"  Region: {bestMatch.Region}");
                Console.WriteLine($"  Měna: {bestMatch.Currency}");

                return bestMatch;
            }

            Console.WriteLine($"Pro '{symbol}' nebyly nalezeny žádné detaily nebo nastala chyba při parsování odpovědi.");
        }
        catch (ApiException apiEx)
        {
            Console.WriteLine($"Chyba API při získávání detailů pro '{symbol}': {apiEx.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Neznámá chyba pro '{symbol}': {e.Message}");
        }

        return null;
    }

    // Pomocná třída pro deserializaci JSON odpovědi z OVERVIEW
    public class SymbolOverview
    {
        [JsonPropertyName("Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("Sector")]
        public string Sector { get; set; }

        // ... a mnoho dalších polí dle dokumentace
    }

    private const string OpenFigiApiUrl = "https://api.openfigi.com/v3/mapping";

    // Pro produkční použití nebo vyšší limity může být vyžadován API klíč.
    // Zaregistrujte se na webu OpenFIGI a vložte klíč sem, pokud ho máte.
    // Pro anonymní použití jsou limity nižší (viz dokumentace OpenFIGI).
    private const string OpenFigiApiKey = "a08356ad-0452-4313-89b4-226e9906b9a4"; // "YOUR_OPENFIGI_API_KEY_IF ANY";

    public static async Task<FigiInstrumentData?> GetInstrumentDetailsAsync(string bloomberg)
    {
        string[] split = bloomberg.Split('.');
        string ticker = split[0];
        string exchangeCode = split[1];

        var exchange = MarketSuffixTranslator.GetMappingBySuffix(exchangeCode);

        var requestJobs = new List<FigiJob>
        {
            new()
            {
                IdType = "TICKER",
                IdValue = ticker
            }
        };

        string jsonPayload = JsonSerializer.Serialize(requestJobs);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // Nastavení API klíče, pokud je k dispozici
        httpClient.DefaultRequestHeaders.Clear(); // Vyčistit staré hlavičky pro případ opakovaného volání

        if (!string.IsNullOrEmpty(OpenFigiApiKey))
        {
            httpClient.DefaultRequestHeaders.Add("X-OPENFIGI-APIKEY", OpenFigiApiKey);
        }

        try
        {
            Console.WriteLine($"Odesílám požadavek na OpenFIGI pro Ticker: {ticker}, Burza: {exchangeCode}");
            var response = await httpClient.PostAsync(OpenFigiApiUrl, content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Chyba HTTP: {(int)response.StatusCode} {response.ReasonPhrase}");
                Console.WriteLine($"Odpověď serveru: {responseBody}");

                return null;
            }

            // Deserializace odpovědi
            // Struktura odpovědi je pole, kde každý prvek může obsahovat 'data' nebo 'error'
            var mappingResults = JsonSerializer.Deserialize<List<FigiMappingResultContainer>>(responseBody);

            if ((mappingResults != null) && (mappingResults.Count > 0))
            {
                foreach (var resultContainer in mappingResults)
                {
                    if ((resultContainer.Data != null) && (resultContainer.Data.Count > 0))
                    {
                        Console.WriteLine($"Nalezená data pro {ticker} na {exchangeCode}:");

                        // Uvnitř smyčky foreach (var resultContainer in mappingResults)
                        if ((resultContainer.Data != null) && (resultContainer.Data.Count > 1))
                        {
                            FigiInstrumentData preferovanyInstrument = null;

                            foreach (var instrument in resultContainer.Data)
                            {
                                // Příklad kritérií pro CBUK (iShares Core £ Corporate Bond UCITS ETF GBP Dist)
                                if ((instrument.Ticker == ticker) &&
                                    (instrument.ExchCode == exchange.OpenFIGIExchCode)) // nebo porovnání s vaším vstupním kódem burzy
                                {
                                    preferovanyInstrument = instrument;

                                    return preferovanyInstrument;
                                }
                            }

                            if (preferovanyInstrument != null)
                            {
                                // Pracujte s preferovanyInstrument
                            }
                            else
                            {
                                Console.WriteLine("Nepodařilo se automaticky vybrat jednoznačnou shodu z více výsledků. Zkontrolujte vypsané detaily.");
                            }
                        }
                    }
                    else if (resultContainer.Error != null)
                    {
                        Console.WriteLine($"Chyba od OpenFIGI pro {ticker} na {exchangeCode}: {resultContainer.Error.Message} (Kód: {resultContainer.Error.Code})");
                    }
                    else if (resultContainer.Warning != null) // API může vrátit i varování
                    {
                        Console.WriteLine($"Varování od OpenFIGI pro {ticker} na {exchangeCode}: {resultContainer.Warning.Message} (Kód: {resultContainer.Warning.Code})");

                        // Varování může znamenat, že data byla nalezena, ale s nějakou výhradou
                        // Je dobré zkontrolovat, zda resultContainer.Data není také null.
                        if ((resultContainer.Data == null) || (resultContainer.Data.Count == 0))
                        {
                            Console.WriteLine("  (A nebyly nalezeny žádné konkrétní instrumenty pro toto varování.)");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Pro {ticker} na {exchangeCode} nebyly nalezeny žádné instrumenty, chyba ani varování v očekávaném formátu.");
                    }
                }
            }
            else
            {
                Console.WriteLine("OpenFIGI vrátilo prázdnou nebo neočekávanou odpověď (pole výsledků je null nebo prázdné).");
                Console.WriteLine($"Surová odpověď: {responseBody}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Chyba HTTP požadavku: {e.Message}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Chyba při deserializaci JSON: {e.Message}");
            // Zde by bylo dobré vypsat i responseBody, pokud je k dispozici, pro ladění
        }
        catch (Exception e)
        {
            Console.WriteLine($"Neznámá chyba: {e.Message}");
        }

        return null;
    }

    // Pomocné třídy pro požadavek a odpověď
    // přesunuto do samostatného souboru OpenFigiModels.cs
    // public class FigiJob { ... }
    // public class FigiMappingResultContainer { ... }
    // public class FigiInstrumentData { ... }
    // public class FigiError { ... }
}

public class ExchangeMappingInfo
{
    public string ExchangeName { get; set; } // Informativní název burzy
    public string MICCode { get; set; } // Preferovaný MIC kód (např. XLON)
    public string OpenFIGIExchCode { get; set; } // Alternativní OpenFIGI exchCode (např. LN)

    public ExchangeMappingInfo(string name, string mic, string figiExchCode)
    {
        ExchangeName = name;
        MICCode = mic;
        OpenFIGIExchCode = figiExchCode;
    }
}
