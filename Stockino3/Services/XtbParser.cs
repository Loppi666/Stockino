using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace Stockino3.Services;

public class XtbParser
{
    private readonly TransactionContext transactionContext;
    private static readonly HttpClient httpClient = new();
    public const string AlphaApiKey = "9E71JJDSQDAD5CZR";

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
                                 .Where(t =>
                                            !existingProducts.Any(ep =>
                                                                      ep.Symbol == t.Product.Symbol &&
                                                                      ep.Transactions.Any() && // produkt má nějaké transakce
                                                                      ep.Transactions.Any(et => et.ExecutionTime == t.ExecutionTime))
                                          ||
                                            !existingProducts.Any(ep =>
                                                                      ep.Symbol == t.Product.Symbol &&
                                                                      !ep.Transactions.Any() // produkt nemá žádné transakce
                                                                 ))
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

        if (worksheet == null)
            return transactions;

        // Najdi měnu v listu
        string currency = null; // Změna var na string a inicializace
        bool currencyFound = false;

        if (worksheet.LastCellUsed() != null) // Zkontrolujte, zda list není prázdný
        {
            for (int r = 1; r <= worksheet.LastRowUsed().RowNumber(); r++)
            {
                for (int c = 1; c <= worksheet.LastColumnUsed().ColumnNumber(); c++)
                {
                    var cellValue = worksheet.Cell(r, c).GetString();

                    if (cellValue.Trim().Equals("currency", StringComparison.OrdinalIgnoreCase))
                    {
                        currency = worksheet.Cell(r + 1, c).GetString().Trim();
                        currencyFound = true;

                        break;
                    }
                }

                if (currencyFound)
                    break;
            }
        }

        int rowCount = worksheet.LastRowUsed().RowNumber() - 1;

        for (int row = 12; row <= rowCount; row++) // Assuming first row is headers
        {
            string symbol = worksheet.Cell(row, 3).GetString();
            string name = worksheet.Cell(row, 3).GetString();

            // Get or create product from database
            var product = await GetOrCreateProduct(symbol, name, null, currency);

            var transaction = new TransactionEntity()
            {
                ProductId = product.Id,
                Product = product,
                OperationType = OperationType.OPEN,
                Volume = double.TryParse(worksheet.Cell(row, 5).GetString(), out double volume)
                    ? volume
                    : default(double),
                ExecutionTime = DateTime.Parse(worksheet.Cell(row, 6).GetString()),
                Price = double.TryParse(worksheet.Cell(row, 7).GetString(), out double price)
                    ? price * volume
                    : default(double),
                Margin =
                    double.TryParse(worksheet.Cell(row, 8).GetString(), out double margin)
                        ? margin
                        : (double?)null,
                Commission = double.TryParse(worksheet.Cell(row, 9).GetString(), out double commission)
                    ? commission
                    : (double?)null,
                Swap = double.TryParse(worksheet.Cell(row, 10).GetString(), out double swap)
                    ? swap
                    : (double?)null,
                GrossPL = double.TryParse(worksheet.Cell(row, 11).GetString(), out double grossPL)
                    ? grossPL
                    : (double?)null,
                Currency = product.Currency // pokud existuje property
            };

            transactions.Add(transaction);
        }

        worksheet = closePositionSheet ?? workbook.Worksheets.FirstOrDefault();

        if (worksheet == null)
            return transactions;

        // Najdi měnu i v tomto listu
        currency = null; // Reset pro nový list
        currencyFound = false; // Reset pro nový list

        if (worksheet.LastCellUsed() != null) // Zkontrolujte, zda list není prázdný
        {
            for (int r = 1; r <= worksheet.LastRowUsed().RowNumber(); r++)
            {
                for (int c = 1; c <= worksheet.LastColumnUsed().ColumnNumber(); c++)
                {
                    var cellValue = worksheet.Cell(r, c).GetString();

                    if (cellValue.Trim().Equals("currency", StringComparison.OrdinalIgnoreCase))
                    {
                        currency = worksheet.Cell(r + 1, c).GetString().Trim();
                        currencyFound = true;

                        break;
                    }
                }

                if (currencyFound)
                    break;
            }
        }

        rowCount = worksheet.LastRowUsed().RowNumber() - 1;

        for (int row = 14; row <= rowCount; row++) // Assuming first row is headers
        {
            string symbol = worksheet.Cell(row, 3).GetString();
            string name = worksheet.Cell(row, 3).GetString();

            // Get or create product from database
            var product = await GetOrCreateProduct(symbol, name, null, currency);

            var transaction = new TransactionEntity()
            {
                ProductId = product.Id,
                Product = product,
                OperationType = OperationType.CLOSE,
                Volume = double.TryParse(worksheet.Cell(row, 5).GetString(), out double volume)
                    ? volume
                    : default(double),
                ExecutionTime = DateTime.Parse(worksheet.Cell(row, 6).GetString()),
                Price = double.TryParse(worksheet.Cell(row, 7).GetString(), out double price)
                    ? price
                    : default(double),
                Margin =
                    double.TryParse(worksheet.Cell(row, 8).GetString(), out double margin)
                        ? margin
                        : (double?)null,
                Commission = double.TryParse(worksheet.Cell(row, 9).GetString(), out double commission)
                    ? commission
                    : (double?)null,
                Swap = double.TryParse(worksheet.Cell(row, 10).GetString(), out double swap)
                    ? swap
                    : (double?)null,
                GrossPL = double.TryParse(worksheet.Cell(row, 11).GetString(), out double grossPL)
                    ? grossPL
                    : (double?)null,
                Currency = product.Currency // pokud existuje property
            };

            transactions.Add(transaction);
        }

        return transactions;
    }

    private async Task<ProductEntity?> GetOrCreateProduct(string symbol, string name, string isin, string currency)
    {
        var product = transactionContext.Products
                                        .FirstOrDefault(p => p.ProviderIdentificator == symbol);

        if (product == null)
        {
            var figiData = await GetInstrumentDetailsAsync(symbol);

            if (figiData is null)
            {
                return null;
            }

            var ticker = figiData.Ticker + OpenFigiToAlphaVantageMapper.GetAlphaVantageSuffix(figiData.ExchCode);

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

    public async Task<string> GetSymbolOverviewAsync(string symbol)
    {
        // Pro ETF a akcie se používá funkce OVERVIEW
        string requestUrl = $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={Uri.EscapeDataString(symbol)}&apikey={AlphaApiKey}";
        SymbolOverview? overviewData = null;

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            overviewData = JsonSerializer.Deserialize<SymbolOverview>(responseBody);

            if (overviewData != null && !string.IsNullOrEmpty(overviewData.Symbol))
            {
                Console.WriteLine($"\nDetaily pro symbol: {overviewData.Symbol}");
                Console.WriteLine($"  Název: {overviewData.Name}");
                Console.WriteLine($"  Popis: {overviewData.Description}");
                Console.WriteLine($"  Typ aktiva: {overviewData.AssetType}");
                Console.WriteLine($"  Burza: {overviewData.Exchange}");
                Console.WriteLine($"  Měna: {overviewData.Currency}");

                // Můžete přidat výpis dalších relevantních polí z třídy SymbolOverview
                if (overviewData.Description != null && overviewData.Description.ToLower().Contains("treasury bond"))
                {
                    Console.WriteLine("  Potvrzeno: Popis obsahuje 'Treasury Bond'.");
                }
            }
            else if (responseBody.Contains("Thank you for using Alpha Vantage!")) // Detekce chybového hlášení API
            {
                Console.WriteLine($"Chyba při získávání detailů pro '{symbol}'. Možná jste dosáhli limitu API nebo symbol není platný.");
                Console.WriteLine($"Odpověď serveru: {responseBody}");
            }
            else
            {
                Console.WriteLine($"Pro '{symbol}' nebyly nalezeny žádné detaily nebo nastala chyba při parsování odpovědi.");
                Console.WriteLine($"Surová odpověď serveru: {responseBody}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Chyba HTTP požadavku pro '{symbol}': {e.Message}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Chyba při deserializaci JSON pro '{symbol}': {e.Message}");
            // Console.WriteLine($"Surová odpověď serveru: {await response.Content.ReadAsStringAsync()}"); // Odkomentujte pro debug JSON
        }
        catch (Exception e)
        {
            Console.WriteLine($"Neznámá chyba pro '{symbol}': {e.Message}");
        }

        return overviewData!.Symbol;
    }

    // Pomocná třída pro deserializaci JSON odpovědi z OVERVIEW
    // Přidejte sem vlastnosti, které vás zajímají z dokumentace Alpha Vantage
    // https://www.alphavantage.co/documentation/#company-overview
    public class SymbolOverview
    {
        [System.Text.Json.Serialization.JsonPropertyName("Symbol")]
        public string Symbol { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("AssetType")]
        public string AssetType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Description")]
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Exchange")]
        public string Exchange { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Country")]
        public string Country { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Sector")]
        public string Sector { get; set; }

        // ... a mnoho dalších polí dle dokumentace
    }

    private const string OpenFigiApiUrl = "https://api.openfigi.com/v3/mapping";

    // Pro produkční použití nebo vyšší limity může být vyžadován API klíč.
    // Zaregistrujte se na webu OpenFIGI a vložte klíč sem, pokud ho máte.
    // Pro anonymní použití jsou limity nižší (viz dokumentace OpenFIGI).
    private const string OpenFigiApiKey = "a08356ad-0452-4313-89b4-226e9906b9a4"; // "YOUR_OPENFIGI_API_KEY_IF_ANY";

    public static async Task<FigiInstrumentData?> GetInstrumentDetailsAsync(string bloomberg)
    {
        var split = bloomberg.Split('.');
        var ticker = split[0];
        var exchangeCode = split[1];

        var exchange = MarketSuffixTranslator.GetMappingBySuffix(exchangeCode);

        var requestJobs = new List<FigiJob>
        {
            new FigiJob
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
            HttpResponseMessage response = await httpClient.PostAsync(OpenFigiApiUrl, content);

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

            if (mappingResults != null && mappingResults.Count > 0)
            {
                foreach (var resultContainer in mappingResults)
                {
                    if (resultContainer.Data != null && resultContainer.Data.Count > 0)
                    {
                        Console.WriteLine($"Nalezená data pro {ticker} na {exchangeCode}:");

                        // Uvnitř smyčky foreach (var resultContainer in mappingResults)
                        if (resultContainer.Data != null && resultContainer.Data.Count > 1)
                        {
                            FigiInstrumentData preferovanyInstrument = null;

                            foreach (var instrument in resultContainer.Data)
                            {
                                // Příklad kritérií pro CBUK (iShares Core £ Corporate Bond UCITS ETF GBP Dist)
                                if (instrument.Ticker == ticker &&
                                    instrument.ExchCode == exchange.OpenFIGIExchCode) // nebo porovnání s vaším vstupním kódem burzy
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
                        if (resultContainer.Data == null || resultContainer.Data.Count == 0)
                        {
                            Console.WriteLine($"  (A nebyly nalezeny žádné konkrétní instrumenty pro toto varování.)");
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
    
      public async Task<SymbolSearchMatch?> GetSymbolOverviewONalphaAsync(string symbol)
    {
        // Používáme funkci SYMBOL_SEARCH místo OVERVIEW
        string requestUrl = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={Uri.EscapeDataString(symbol)}&apikey={AlphaApiKey}";
        SymbolSearchResult? searchResult = null;

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            searchResult = JsonSerializer.Deserialize<SymbolSearchResult>(responseBody);

            if (searchResult != null && searchResult.BestMatches != null && searchResult.BestMatches.Any())
            {
                // Použijeme první nalezenou shodu
                SymbolSearchMatch bestMatch = searchResult.BestMatches.First();

                Console.WriteLine($"\nDetaily pro symbol: {bestMatch.Symbol}");
                Console.WriteLine($"  Název: {bestMatch.Name}");
                Console.WriteLine($"  Typ: {bestMatch.Type}");
                Console.WriteLine($"  Region: {bestMatch.Region}");
                Console.WriteLine($"  Měna: {bestMatch.Currency}");

                return bestMatch;
            }
            else if (responseBody.Contains("Thank you for using Alpha Vantage!"))
            {
                Console.WriteLine($"Chyba při získávání detailů pro '{symbol}'. Možná jste dosáhli limitu API nebo symbol není platný.");
                Console.WriteLine($"Odpověď serveru: {responseBody}");
            }
            else
            {
                Console.WriteLine($"Pro '{symbol}' nebyly nalezeny žádné detaily nebo nastala chyba při parsování odpovědi.");
                Console.WriteLine($"Surová odpověď serveru: {responseBody}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Chyba HTTP požadavku pro '{symbol}': {e.Message}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Chyba při deserializaci JSON pro '{symbol}': {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Neznámá chyba pro '{symbol}': {e.Message}");
        }

        return null;
    }

    // Pomocné třídy pro požadavek a odpověď
    public class FigiJob
    {
        [System.Text.Json.Serialization.JsonPropertyName("idType")]
        public string IdType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idValue")]
        public string IdValue { get; set; }

        // Další volitelné parametry dle dokumentace OpenFIGI v3:
        // https://www.openfigi.com/api#request-body
        // Například: seriesNumber, classFIGI, securityType, securityType2, stateCode, monthYear
    }

    public class FigiMappingResultContainer
    {
        [System.Text.Json.Serialization.JsonPropertyName("data")]
        public List<FigiInstrumentData> Data { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("error")]
        public FigiError Error { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("warning")]
        public FigiError Warning { get; set; }
    }

    public class FigiInstrumentData
    {
        [System.Text.Json.Serialization.JsonPropertyName("figi")]
        public string Figi { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; } // Toto pole je často obecnější, preferujte securityDescription

        [System.Text.Json.Serialization.JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("exchCode")]
        public string ExchCode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("compositeFIGI")]
        public string CompositeFigi { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("securityType")]
        public string SecurityType { get; set; } // Např. "Common Stock"

        [System.Text.Json.Serialization.JsonPropertyName("marketSector")]
        public string MarketSector { get; set; } // Např. "Equity", "Government"

        [System.Text.Json.Serialization.JsonPropertyName("securityDescription")]
        public string SecurityDescription { get; set; } // Toto je obvykle nejpodrobnější název/popis

        [System.Text.Json.Serialization.JsonPropertyName("securityType2")]
        public string SecurityType2 { get; set; } // Detailnější typ
        
        [System.Text.Json.Serialization.JsonPropertyName("currency")]
        public string Currency { get; set; } // Např. "USD", "EUR", "GBP"

        // Mohou zde být další pole v závislosti na typu instrumentu a odpovědi API
    }

    public class FigiError
    {
        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public int Code { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("message")]
        public string Message { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; } // Identifikátor, který způsobil chybu (pokud je relevantní)
    }
}

public static class MarketSuffixTranslator
{
    // Inicializace slovníku přímo v kódu
    private static readonly Dictionary<string, ExchangeMappingInfo> SuffixMap = new Dictionary<string, ExchangeMappingInfo>(StringComparer.OrdinalIgnoreCase)
    {
        // === Evropa ===
        { "UK", new ExchangeMappingInfo("London Stock Exchange", "XLON", "LN") }, // Spojené království
        { "DE_XETRA", new ExchangeMappingInfo("Xetra", "XETR", "XE") }, // Německo - Xetra (hlavní)
        { "DE_FRANKFURT", new ExchangeMappingInfo("Frankfurt Stock Exchange (Börse Frankfurt)", "XFRA", "FF") }, // Německo - Frankfurt
        { "DE_STUTTGART", new ExchangeMappingInfo("Stuttgart Stock Exchange (Börse Stuttgart)", "XSTU", "SG") }, // Německo - Stuttgart
        { "FR", new ExchangeMappingInfo("Euronext Paris", "XPAR", "PA") }, // Francie
        { "NL", new ExchangeMappingInfo("Euronext Amsterdam", "XAMS", "AE") }, // Nizozemsko
        { "BE", new ExchangeMappingInfo("Euronext Brussels", "XBRU", "BR") }, // Belgie
        { "PT", new ExchangeMappingInfo("Euronext Lisbon", "XLIS", "LS") }, // Portugalsko
        { "IE", new ExchangeMappingInfo("Euronext Dublin", "XMSM", "ID") }, // Irsko
        { "ES", new ExchangeMappingInfo("Bolsa de Madrid", "XMAD", "SM") }, // Španělsko
        { "IT", new ExchangeMappingInfo("Borsa Italiana (Euronext Milan)", "XMIL", "IM") }, // Itálie
        { "CH", new ExchangeMappingInfo("SIX Swiss Exchange", "XSWX", "VX") }, // Švýcarsko
        { "SE", new ExchangeMappingInfo("Nasdaq Stockholm", "XSTO", "ST") }, // Švédsko
        { "NO", new ExchangeMappingInfo("Oslo Børs (Euronext Oslo)", "XOSL", "OL") }, // Norsko
        { "DK", new ExchangeMappingInfo("Nasdaq Copenhagen", "XCSE", "CO") }, // Dánsko
        { "FI", new ExchangeMappingInfo("Nasdaq Helsinki", "XHEL", "HE") }, // Finsko
        { "PL", new ExchangeMappingInfo("Warsaw Stock Exchange (GPW)", "XWAR", "WA") }, // Polsko
        { "AT", new ExchangeMappingInfo("Wiener Börse (Vienna Stock Exchange)", "XWBO", "VI") }, // Rakousko
        { "GR", new ExchangeMappingInfo("Athens Stock Exchange (ATHEX)", "XATH", "AS") }, // Řecko (OpenFIGI exchCode 'AS')
        { "HU", new ExchangeMappingInfo("Budapest Stock Exchange", "XBUD", "BU") }, // Maďarsko
        { "CZ", new ExchangeMappingInfo("Prague Stock Exchange (PSE)", "XPRA", "PR") }, // Česká republika
        { "LU", new ExchangeMappingInfo("Luxembourg Stock Exchange", "XLUX", "LU") }, // Lucembursko
        { "TR", new ExchangeMappingInfo("Borsa Istanbul", "XIST", "IS") }, // Turecko (OpenFIGI exchCode 'IS')

        // === Severní Amerika ===
        { "US_NYSE", new ExchangeMappingInfo("New York Stock Exchange", "XNYS", "US") }, // USA - NYSE
        { "US_NASDAQ", new ExchangeMappingInfo("NASDAQ Stock Market", "XNAS", "US") }, // USA - NASDAQ
        { "US_AMEX", new ExchangeMappingInfo("NYSE American (AMEX)", "XASE", "US") }, // USA - AMEX
        // { "US", new ExchangeMappingInfo("Generic US (default NASDAQ)", "XNAS", "US") }, // Pokud máte obecný ".US" sufix
        { "CA_TSX", new ExchangeMappingInfo("Toronto Stock Exchange", "XTSE", "CA") }, // Kanada - TSX
        { "CA_TSXV", new ExchangeMappingInfo("TSX Venture Exchange", "XTSX", "CA") }, // Kanada - TSX Venture (MIC je stejný, OpenFIGI 'CA' je obecný)
        { "MX", new ExchangeMappingInfo("Mexican Stock Exchange (BMV)", "XMEX", "MX") }, // Mexiko

        // === Asie a Pacifik ===
        { "AU", new ExchangeMappingInfo("Australian Securities Exchange", "XASX", "AX") }, // Austrálie
        { "NZ", new ExchangeMappingInfo("New Zealand Exchange (NZX)", "XNZE", "NZ") }, // Nový Zéland
        { "JP", new ExchangeMappingInfo("Tokyo Stock Exchange", "XTKS", "TJ") }, // Japonsko (součást XJPX)
        { "HK", new ExchangeMappingInfo("Hong Kong Stock Exchange", "XHKG", "HK") }, // Hongkong
        { "SG", new ExchangeMappingInfo("Singapore Exchange", "XSES", "SI") }, // Singapur
        { "CN_SS", new ExchangeMappingInfo("Shanghai Stock Exchange", "XSHG", "SH") }, // Čína - Šanghaj
        { "CN_SZ", new ExchangeMappingInfo("Shenzhen Stock Exchange", "XSHE", "SZ") }, // Čína - Šen-čen
        { "IN_NSE", new ExchangeMappingInfo("National Stock Exchange of India", "XNSE", "IN") }, // Indie - NSE
        { "IN_BSE", new ExchangeMappingInfo("BSE India (Bombay Stock Exchange)", "XBOM", "IN") }, // Indie - BSE
        { "KR", new ExchangeMappingInfo("Korea Exchange (KRX)", "XKRX", "KO") }, // Jižní Korea
        { "TW", new ExchangeMappingInfo("Taiwan Stock Exchange (TWSE)", "XTAI", "TW") }, // Tchaj-wan
        { "ID", new ExchangeMappingInfo("Indonesia Stock Exchange (IDX)", "XIDX", "JK") }, // Indonésie (OpenFIGI 'JK' pro Jakarta)
        { "TH", new ExchangeMappingInfo("Stock Exchange of Thailand (SET)", "XBKK", "BK") }, // Thajsko (OpenFIGI 'BK' pro Bangkok)
        { "MY", new ExchangeMappingInfo("Bursa Malaysia", "XKLS", "KL") }, // Malajsie (OpenFIGI 'KL' pro Kuala Lumpur)
        { "PH", new ExchangeMappingInfo("Philippine Stock Exchange (PSE)", "XPHS", "PM") }, // Filipíny (OpenFIGI 'PM' pro Manila)

        // === Jižní Amerika ===
        { "BR", new ExchangeMappingInfo("B3 - Brasil Bolsa Balcão", "BVMF", "BZ") }, // Brazílie
        { "AR", new ExchangeMappingInfo("Bolsas y Mercados Argentinos (BYMA)", "XBYM", "BA") }, // Argentina (OpenFIGI 'BA' pro Buenos Aires)
        { "CL", new ExchangeMappingInfo("Santiago Stock Exchange", "XSGO", "CI") }, // Chile (OpenFIGI 'CI')
        { "CO", new ExchangeMappingInfo("Colombia Stock Exchange (BVC)", "XBOG", "CO") }, // Kolumbie (OpenFIGI 'CO')
        { "PE", new ExchangeMappingInfo("Bolsa de Valores de Lima (BVL)", "XLIM", "LM") }, // Peru (OpenFIGI 'LM' pro Lima)

        // === Blízký východ a Afrika ===
        { "ZA", new ExchangeMappingInfo("JSE Limited (Johannesburg)", "XJSE", "JH") }, // Jihoafrická republika
        { "SA", new ExchangeMappingInfo("Saudi Stock Exchange (Tadawul)", "XSAU", "SA") }, // Saudská Arábie
        { "AE_DFM", new ExchangeMappingInfo("Dubai Financial Market (DFM)", "XDFM", "DB") }, // SAE - Dubai (OpenFIGI 'DB')
        { "AE_ADX", new ExchangeMappingInfo("Abu Dhabi Securities Exchange (ADX)", "XADS", "AD") }, // SAE - Abu Dhabi
        { "QA", new ExchangeMappingInfo("Qatar Stock Exchange", "XQAT", "DSMH") }, // Katar (OpenFIGI 'DSMH' pro Doha) - XQAT je MIC, dříve DSM
        { "IL", new ExchangeMappingInfo("Tel Aviv Stock Exchange (TASE)", "XTAE", "TA") }, // Izrael
        { "EG", new ExchangeMappingInfo("Egyptian Exchange (EGX)", "XCAI", "EG") } // Egypt (OpenFIGI 'CA' pro Cairo, ale EG je země) - EG se zdá být OK pro OpenFIGI

        // Doplňte další dle potřeby. Ověřujte MIC kódy a OpenFIGI exchCodes pro přesnost.
        // Pro OpenFIGI exchCode je někdy potřeba trochu hledat nebo testovat,
        // např. na webu OpenFIGI v sekci Symbology nebo testováním s známými instrumenty.
    };

    public static ExchangeMappingInfo GetMappingBySuffix(string suffix)
    {
        if (SuffixMap.TryGetValue(suffix, out ExchangeMappingInfo mappingInfo))
        {
            return mappingInfo;
        }

        Console.WriteLine($"Varování: Pro sufix '{suffix}' nebylo nalezeno žádné předdefinované mapování.");

        return null;
    }
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

public static class OpenFigiToAlphaVantageMapper
{
    // Klíč: OpenFIGI exchCode (např. "LN", "US", "XE")
    // Hodnota: Alpha Vantage ticker suffix (např. ".L", "", ".DE")
    private static readonly Dictionary<string, string> FigiExchCodeToAlphaVantageSuffixMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // === Evropa ===
        { "LN", ".L" }, // London Stock Exchange (UK)
        { "XE", ".DE" }, // Xetra (Německo)
        { "FF", ".F" }, // Frankfurt Stock Exchange (Německo - Alpha Vantage často používá .F pro Frankfurt, .DE pro Xetra)
        { "SG", ".SG" }, // Stuttgart Stock Exchange (Německo - .SG nebo .DU pro Düsseldorf, ověřit pro Stuttgart) - Alpha Vantage používá .STU pro Stuttgart
        { "PA", ".PA" }, // Euronext Paris (Francie)
        { "AE", ".AS" }, // Euronext Amsterdam (Nizozemsko - Alpha Vantage používá .AS)
        { "BR", ".BR" }, // Euronext Brussels (Belgie)
        { "LS", ".LS" }, // Euronext Lisbon (Portugalsko)
        { "ID", ".IR" }, // Euronext Dublin (Irsko - Alpha Vantage používá .IR)
        { "SM", ".MA" }, // Bolsa de Madrid (Španělsko - Alpha Vantage používá .MA)
        { "IM", ".MI" }, // Borsa Italiana / Euronext Milan (Itálie - Alpha Vantage používá .MI)
        { "VX", ".SW" }, // SIX Swiss Exchange (Švýcarsko - Alpha Vantage používá .SW)
        { "ST", ".ST" }, // Nasdaq Stockholm (Švédsko)
        { "OL", ".OL" }, // Oslo Børs (Norsko)
        { "CO", ".CO" }, // Nasdaq Copenhagen (Dánsko)
        { "HE", ".HE" }, // Nasdaq Helsinki (Finsko)
        { "WA", ".WA" }, // Warsaw Stock Exchange (Polsko - .WA nebo .WAR, .WA je častější)
        { "VI", ".VI" }, // Wiener Börse / Vienna Stock Exchange (Rakousko)
        { "AS", ".AT" }, // Athens Stock Exchange (Řecko - Alpha Vantage používá .AT)
        { "BU", ".BU" }, // Budapest Stock Exchange (Maďarsko)
        { "PR", ".PR" }, // Prague Stock Exchange (Česká republika - .PR nebo .PRA)
        { "LU", ".LU" }, // Luxembourg Stock Exchange
        { "IS", ".IS" }, // Borsa Istanbul (Turecko)

        // === Severní Amerika ===
        // Pro hlavní US burzy Alpha Vantage typicky NEPOUŽÍVÁ sufix pro akcie.
        // Symbol je přímo ticker, např. "IBM", "AAPL".
        // OpenFIGI může vrátit "US" jako obecný exchCode.
        // Pokud víte, že jde o NYSE/NASDAQ akcii, sufix je prázdný.
        { "US", "" }, // Obecný US - pro akcie NYSE/NASDAQ je sufix prázdný. Pro jiné US instrumenty může být sufix potřeba.
        // Toto mapování je zjednodušení. Pokud OpenFIGI vrátí "US", musíte zvážit typ instrumentu.
        { "CA", ".TO" }, // Toronto Stock Exchange (TSX, Kanada). Pro TSX Venture (TSXV) by to bylo .VN
        // OpenFIGI "CA" může být obecné, toto je pro hlavní TSX.

        { "MX", ".MX" }, // Mexican Stock Exchange (Mexiko)

        // === Asie a Pacifik ===
        { "AX", ".AX" }, // Australian Securities Exchange (Austrálie)
        { "NZ", ".NZ" }, // New Zealand Exchange (NZX)
        { "TJ", ".T" }, // Tokyo Stock Exchange (Japonsko - Alpha Vantage používá .T)
        { "HK", ".HK" }, // Hong Kong Stock Exchange
        { "SI", ".SI" }, // Singapore Exchange
        { "SH", ".SS" }, // Shanghai Stock Exchange (Čína - Alpha Vantage používá .SS)
        { "SZ", ".SZ" }, // Shenzhen Stock Exchange (Čína - Alpha Vantage používá .SZ)
        { "IN", ".NS" }, // National Stock Exchange of India (Indie - .NS pro NSE, .BO pro BSE. "IN" z OpenFIGI je obecné)
        // Je lepší mít specifické mapování, pokud víte, zda je to NSE nebo BSE.
        { "KO", ".KS" }, // Korea Exchange (Jižní Korea - Alpha Vantage často používá .KS pro KOSPI)
        { "TW", ".TW" }, // Taiwan Stock Exchange
        { "JK", ".JK" }, // Indonesia Stock Exchange (Jakarta)
        { "BK", ".BK" }, // Stock Exchange of Thailand (Bangkok)
        { "KL", ".KL" }, // Bursa Malaysia (Kuala Lumpur)
        { "PM", ".PM" }, // Philippine Stock Exchange (Manila)

        // === Jižní Amerika ===
        { "BZ", ".SA" }, // B3 - Brasil Bolsa Balcão (Brazílie - Alpha Vantage používá .SA pro Sao Paulo)
        { "CI", ".SN" }, // Santiago Stock Exchange (Chile - Alpha Vantage používá .SN)
        // { "CO", ".CB" }, // Colombia Stock Exchange - Alpha Vantage má pro Kolumbii specifické symboly, nemusí jít o jednoduchý sufix
        { "LM", ".LM" }, // Bolsa de Valores de Lima (Peru)
        { "BA", ".BA" }, // Bolsas y Mercados Argentinos (Argentina)

        // === Blízký východ a Afrika ===
        { "JH", ".JO" }, // JSE Limited (Jihoafrická republika - Alpha Vantage používá .JO pro Johannesburg)
        // { "SA", ".SR" }, // Saudi Stock Exchange (Tadawul - Alpha Vantage .SR, ale OpenFIGI může vracet SA)
        { "DB", ".DU" }, // Dubai Financial Market (SAE - Alpha Vantage často .DU)
        { "AD", ".AE" }, // Abu Dhabi Securities Exchange (SAE - Alpha Vantage někdy .AE) - ověřit!
        // { "DSMH", X },   // Qatar Stock Exchange - Alpha Vantage má omezené pokrytí nebo specifické symboly
        { "TA", ".TA" }, // Tel Aviv Stock Exchange (Izrael - .TA nebo .TLV)
        { "EG", ".CAI" } // Egyptian Exchange (Egypt - Alpha Vantage může používat .CAI pro Káhira) - ověřit!

        // TENTO SEZNAM NENÍ VYČERPÁVAJÍCÍ A MĚL BY BÝT OVĚŘOVÁN A DOPLŇOVÁN!
    };

    public static string GetAlphaVantageSuffix(string openFigiExchCode)
    {
        if (string.IsNullOrWhiteSpace(openFigiExchCode))
        {
            return null; // Nebo prázdný řetězec, pokud je to preferováno pro "bez sufixu"
        }

        if (FigiExchCodeToAlphaVantageSuffixMap.TryGetValue(openFigiExchCode, out string alphaVantageSuffix))
        {
            return alphaVantageSuffix;
        }

        Console.WriteLine($"Varování: Pro OpenFIGI exchCode '{openFigiExchCode}' nebylo nalezeno žádné mapování na Alpha Vantage sufix.");

        return null; // Nebo nějaká výchozí hodnota / chování
    }

    // Metoda pro sestrojení celého Alpha Vantage symbolu
    public static string ConstructAlphaVantageSymbol(string baseTicker, string openFigiExchCode)
    {
        if (string.IsNullOrWhiteSpace(baseTicker))
            return null;

        string suffix = GetAlphaVantageSuffix(openFigiExchCode);

        if (suffix == null)
        {
            // Pokud sufix není nalezen, můžeme zkusit vrátit jen baseTicker (pro případ US trhů, kde je sufix prázdný)
            // Ale je lepší, když mapování pro "US" explicitně vrací ""
            Console.WriteLine($"Nebyl nalezen sufix pro {openFigiExchCode}, zkouším použít base ticker '{baseTicker}' bez sufixu.");

            return baseTicker;
        }

        // Pokud je sufix prázdný řetězec (např. pro US trhy), vrátíme jen baseTicker
        if (suffix == "")
        {
            return baseTicker;
        }

        return $"{baseTicker}{suffix}";
    }
}

public class SymbolSearchResult
{
    [JsonPropertyName("bestMatches")]
    public List<SymbolSearchMatch>? BestMatches { get; set; }
}

public class SymbolSearchMatch
{
    [JsonPropertyName("1. symbol")]
    public string? Symbol { get; set; }
    
    [JsonPropertyName("2. name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("3. type")]
    public string? Type { get; set; }
    
    [JsonPropertyName("4. region")]
    public string? Region { get; set; }
    
    [JsonPropertyName("8. currency")]
    public string? Currency { get; set; }
}

