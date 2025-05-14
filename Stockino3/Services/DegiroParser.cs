using System.Globalization;
using System.Text;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace Stockino3.Services;

public class DegiroParser : IService
{
    private readonly TransactionContext transactionContext;
    private readonly IOpenFigiApi openFigiApi;
    private readonly IAlphaVantageApi alphaVantageApi;
    
      public static Dictionary<string, string> DegiroMicToOpenFigiExchangeCode = new Dictionary<string, string>
    {
        // DEGIRO: "EURONEXT - EURONEXT AMSTERDAM" (Netherlands) -> XAMS
        // OpenFIGI: "the Euronext Amsterdam Stock Exchange" (NL), Code: NA
        { "XAMS", "NA" },

        // DEGIRO: "EURONEXT - EURONEXT PARIS" (France) -> XPAR
        // OpenFIGI: "the Euronext Paris Stock Exchange" (FR), Code: FP
        { "XPAR", "FP" },

        // DEGIRO: "EURONEXT - EURONEXT BRUSSELS" (Belgium) -> XBRU
        // OpenFIGI: "EN Brussels" / "Brussel NM" (BE), Code: BB (Full name not explicitly Euronext Brussels, but contextually matches)
        { "XBRU", "BB" },

        // DEGIRO: "EURONEXT - EURONEXT LISBON" (Portugal) -> XLIS
        // OpenFIGI: "the Euronext Lisbon Stock Exchange" (PT), Code: PL
        { "XLIS", "PL" },

        // DEGIRO: "EURONEXT MILAN" (Italy) -> MTAA
        // OpenFIGI: "Milan NM" / "BrsaItaliana" (IT) (Borsa Italiana is part of Euronext Group), Code: IM
        { "MTAA", "IM" },

        // DEGIRO: "BOERSE FRANKFURT - REGULIERTER MARKT" (Germany) -> FRAA
        // OpenFIGI: "the Frankfurt Stock Exchange" (DE), Code: GF
        { "FRAA", "GF" },
        // DEGIRO: "BOERSE FRANKFURT - FREIVERKEHR" (Germany) -> FRAB
        // OpenFIGI: "the Frankfurt Stock Exchange" (DE), Code: GF
        { "FRAB", "GF" },
        // DEGIRO: "BOERSE FRANKFURT - SCALE" (Germany) -> FRAS
        // OpenFIGI: "the Frankfurt Stock Exchange" (DE), Code: GF (Assuming Scale is a segment of Frankfurt)
        { "FRAS", "GF" },
        // DEGIRO: "DEUTSCHE BOERSE AG" (Germany) -> XFRA
        // OpenFIGI: "the Frankfurt Stock Exchange" (DE), Code: GF (Deutsche Boerse is operator of Frankfurt SE)
        { "XFRA", "GF" },

        // DEGIRO: "XETRA - REGULIERTER MARKT" (Germany) -> XETA (PDF uses ΧΕΤΑ)
        // OpenFIGI: "the Xetra Stock Exchange" (DE), Code: GY
        
        { "XETA", "GT" }, // Assuming DEGIRO MIC 'ΧΕΤΑ' corresponds to standard 'XETA' for Xetra
        { "XGAT", "GY" }, // Assuming DEGIRO MIC 'ΧΕΤΑ' corresponds to standard 'XETA' for Xetra
        { "XETB", "GY" }, // Assuming DEGIRO MIC 'ΧΕΤΑ' corresponds to standard 'XETA' for Xetra

        // DEGIRO: "SIX SWISS EXCHANGE" (Switzerland) -> XSWX
        // OpenFIGI: "the SIX Swiss Exchange" (CH), Code: SE
        { "XSWX", "SE" },

        // DEGIRO: "NASDAQ STOCKHOLM AB" (Sweden) -> XSTO
        // OpenFIGI: "Stockholm" (Full Name: "Nordic Growth Market" also "Spotlight Stock Market" for SS, using 'SS' for main Stockholm market) (SE), Code: SS
        { "XSTO", "SS" }, // Note: OpenFIGI names for SS are varied, matching "Stockholm" and country.

        // DEGIRO: "OSLO BORS" (Norway) -> XOSL
        // OpenFIGI: "the Oslo Stock Exchange" (NO), Code: NO
        { "XOSL", "NO" },

        // DEGIRO: "NASDAQ COPENHAGEN A/S" (Denmark) -> XCSE
        // OpenFIGI: "the Copenhagen Stock Exchange" (DK), Code: DC
        { "XCSE", "DC" },

        // DEGIRO: "NASDAQ HELSINKI LTD" (Finland) -> XHEL
        // OpenFIGI: "the Helsinki Stock Exchange" (FI), Code: FH
        { "XHEL", "FH" },

        // DEGIRO: "BOLSA DE MADRID" (Spain) -> XMAD
        // OpenFIGI: "Sociedad de Bolsas" / SIBE platform (ES) (Represents the Spanish electronic market), Code: SQ
        { "XMAD", "SQ" },

        // DEGIRO: "LONDON STOCK EXCHANGE" (United Kingdom) -> XLON
        // OpenFIGI: "London" / "the Tradepoint Investment Exchange" (GB), Code: LN
        { "XLON", "LN" },

        // DEGIRO: "NEW YORK STOCK EXCHANGE, INC." (United States of America) -> XNYS
        // OpenFIGI: "the New York Stock Exchange" (US), Code: UN
        // New York / NYSE related (map to UN)
        { "XNYS", "UN" }, // DUPLICITA, SMAZÁNO
        
        // { "XASE", "UN" }, // DUPLICITA, SMAZÁNO
        // { "XCHI", "UN" }, // DUPLICITA, SMAZÁNO
        // { "XCIS", "UN" }, // DUPLICITA, SMAZÁNO

        // NASDAQ related (map to UW)
         { "XNAS", "UW" }, // DUPLICITA, SMAZÁNO
        // { "XBOS", "UW" }, // DUPLICITA, SMAZÁNO
        // { "XPSX", "UW" }, // DUPLICITA, SMAZÁNO

        { "SOHO", "UN" }, // TWO SIGMA SECURITIES, LLC (user example)
 
        // { "EDGA", "UN" }, // DUPLICITA, SMAZÁNO
        // { "EDGX", "UN" }, // DUPLICITA, SMAZÁNO
        { "EPRL", "UN" }, // MIAX PEARL EQUITIES
        // { "IEXG", "UN" }, // DUPLICITA, SMAZÁNO
        { "LTSE", "UN" }, // LONG-TERM STOCK EXCHANGE, INC.
        { "MEMX", "UN" }, // MEMX LLC EQUITIES
        { "CDED", "UN" }, // CITADEL SECURITIES (Systematic Internaliser)
        { "JNST", "UN" }, // JANE STREET CAPITAL, LLC (Systematic Internaliser)
        { "HRTF", "UN" }, // HUDSON RIVER TRADING (HRT) (Systematic Internaliser)
        { "MSCO", "UN" }, // MORGAN STANLEY AND CO. LLC (Systematic Internaliser)
        { "MSPL", "UN" } , // MS POOL (Morgan Stanley's dark pool)

        // DEGIRO: "NYSE ARCA" (United States of America) -> ARCX
        // OpenFIGI: "the NYSE Arca Exchange" (US), Code: UP
        { "ARCX", "UP" },

       
        // DEGIRO: "CBOE BZX U.S. EQUITIES EXCHANGE" (United States of America) -> BATS
        // OpenFIGI: "Cboe BZX Exchange (Cboe BZX)" (US), Code: UF
        { "BATS", "UF" },

        // DEGIRO: "CBOE BYX U.S. EQUITIES EXCHANGE" (United States of America) -> BATY
        // OpenFIGI: "Cboe BYX Exchange (Cboe BYX)" (US), Code: VY
        { "BATY", "VY" },

        // DEGIRO: "CBOE EDGA U.S. EQUITIES EXCHANGE" (United States of America) -> EDGA
        // OpenFIGI: "the EDGA Stock Exchange" (US), Code: VJ
        { "EDGA", "VJ" },

        // DEGIRO: "CBOE EDGX U.S. EQUITIES EXCHANGE" (United States of America) -> EDGX
        // OpenFIGI: "the EDGX Stock Exchange" (US), Code: VK
        { "EDGX", "VK" },

        // DEGIRO: "NASDAQ OMX BX" (United States of America) -> XBOS
        // OpenFIGI: "the Nasdaq OMX BX Exchange" (US), Code: UB
        { "XBOS", "UB" },

        // DEGIRO: "NYSE CHICAGO, INC." (United States of America) -> XCHI
        // OpenFIGI: "NYSE Chicago" (US), Code: UM
        { "XCHI", "UM" },

        // DEGIRO: "NYSE NATIONAL, INC." (United States of America) -> XCIS
        // OpenFIGI: "NYSE National" (US), Code: UC
        { "XCIS", "UC" },

        // DEGIRO: "NASDAQ OMX PSX" (United States of America) -> XPSX
        // OpenFIGI: "the NASDAQ OMX PSX Exchange" (US), Code: UX
        { "XPSX", "UX" },

        // DEGIRO: "INVESTORS EXCHANGE" (United States of America) -> IEXG
        // OpenFIGI: "Investors Exchange" (US), Code: VF
        { "IEXG", "VF" },

        // DEGIRO: "NYSE MKT LLC" (United States of America) -> XASE
        // OpenFIGI: "NYSE American" (US), Code: UA
        { "XASE", "UA" },

        // DEGIRO: "TOKYO STOCK EXCHANGE" (Japan) -> XTKS
        // OpenFIGI: "the Tokyo Stock Exchange" (JP), Code: JT
        { "XTKS", "JT" },

        // DEGIRO: "HONG KONG EXCHANGES AND CLEARING LTD" (Hong Kong) -> XHKG
        // OpenFIGI: "the Hong Kong Stock Exchange" (HK), Code: HK
        { "XHKG", "HK" },

        // DEGIRO: "SINGAPORE EXCHANGE" (Singapore) -> XSES
        // OpenFIGI: "the Stock Exchange of Singapore" (SG), Code: SP
        { "XSES", "SP" },

        // DEGIRO: "ASX TRADEMATCH" (Australia) -> ASXT (Name is specific, "ASX" is key)
        // OpenFIGI: "the Australian Stock Exchange" (AU), Code: AN
        { "ASXT", "AN" },

        // DEGIRO: "TORONTO STOCK EXCHANGE" (Canada) -> XTSE
        // OpenFIGI: "the Toronto Stock Exchange" (CA), Code: CT
        { "XTSE", "CT" },

        // DEGIRO: "TSX VENTURE EXCHANGE" (Canada) -> XTSX
        // OpenFIGI: "the Canadian Venture Exchange" (CA), Code: CV
        { "XTSX", "CV" },

        // DEGIRO: "CANADIAN SECURITIES EXCHANGE" (Canada) -> XCNQ
        // OpenFIGI: "the Canadian Securities Exchange" (CA), Code: CF
        { "XCNQ", "CF" },

        // DEGIRO: "PRAGUE STOCK EXCHANGE" (Czech Republic) -> XPRA
        // OpenFIGI: "the Prague Stock Exchange" (CZ), Code: CK
        { "XPRA", "CK" },

        // DEGIRO: "WARSAW STOCK" (Poland) -> XWAR
        // OpenFIGI: "the Warsaw Auction Market" (PL), Code: PW (OpenFIGI has several Warsaw entries, PW is one specific market type)
        { "XWAR", "PW" },

        // DEGIRO: "ATHENS EXCHANGE S.A. CASH MARKET" (Greece) -> XATH
        // OpenFIGI: "the Athens Stock Exchange" (GR), Code: GA
        { "XATH", "GA" },

        // DEGIRO: "WIENER BOERSE AG VIENNA MTF (VIENNA MTF)" (Austria) -> WBDM
        // OpenFIGI: "the Vienna Stock Exchange" (AT), Code: AV
        { "WBDM", "AV" },
        // DEGIRO: "WIENER BOERSE AG AMTLICHER HANDEL (OFFICIAL MARKET)" (Austria) -> WBAH
        // OpenFIGI: "the Vienna Stock Exchange" (AT), Code: AV
        { "WBAH", "AV" },
        { "FSME", "FF" }
    };
    public DegiroParser(TransactionContext transactionContext, IOpenFigiApi openFigiApi, IAlphaVantageApi alphaVantageApi)
    {
        this.transactionContext = transactionContext;
        this.openFigiApi = openFigiApi;
        this.alphaVantageApi = alphaVantageApi;
    }

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
            await csv.ReadAsync();
            csv.ReadHeader();

            // Get existing products and transactions
            var transactionModels = csv.GetRecords<TransactionCsvModel>()
                                       .Where(x => !x.ISIN.IsNullOrEmpty())
                                       .ToList();

            var uniqueProducts = transactionModels
                                .Where(x => !string.IsNullOrEmpty(x.ISIN) && !string.IsNullOrEmpty(x.Exchange))
                                .GroupBy(x => new
                                 {
                                     x.ISIN,
                                     x.Exchange
                                 })
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
                var entity = await MapCsvToEntity(model);
                
                if (entity is null)
                {
                    continue;
                }
                    
                transactions.Add(entity);
            }

            // Get existing transactions from database
            var existingTransactions = await transactionContext.Transactions
                                                               .ToListAsync();

            // Filter out transactions that already exist by checking key transaction properties
            var newTransactions = transactions
                                 .Where(t => !existingTransactions.Any(et =>
                                                                           (et.ProductId == t.ProductId) &&
                                                                           (et.ExecutionTime == t.ExecutionTime) &&
                                                                           (et.OperationType == t.OperationType) &&
                                                                           (Math.Abs(et.Volume - t.Volume) < 0.001m) &&
                                                                           (Math.Abs(et.UnitPrice - t.UnitPrice) < 0.001m)))
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

    private async Task<TransactionEntity?> MapCsvToEntity(TransactionCsvModel csvModel)
    {
        // Parse the date and time
        DateTime executionTime;

        if (!string.IsNullOrEmpty(csvModel.Time))
        {
            // If time is available, combine with date
            executionTime = DateTime.ParseExact($"{csvModel.DateString} {csvModel.Time}",
                                                "dd-MM-yyyy HH:mm",
                                                CultureInfo.InvariantCulture);
        }
        else
        {
            // If only date is available
            executionTime = csvModel.Date;
        }

        // Determine operation type based on quantity (negative is CLOSE/sell, positive is OPEN/buy)
        var operationType = csvModel.Quantity < 0
            ? OperationType.CLOSE
            : OperationType.OPEN;

        // Get or create the product
        string symbol = csvModel.ISIN ?? csvModel.Product;
        var product = await GetOrCreateProduct(symbol, csvModel.Product, csvModel.ISIN, csvModel.Exchange);

        if (product is null)
        {
            return null;
        }
        
        return new TransactionEntity
        {
            ProductId = product.Id,
            OperationType = operationType,
            Volume = Math.Abs(csvModel.Quantity), // Use absolute value for volume
            ExecutionTime = executionTime,
            UnitPrice = csvModel.Price,
            BuyInCurrency = csvModel.TotalCurreny,
            // Other fields don't have direct mappings in CSV, so leaving as null
            Margin = null,
            Commission = null,
            Swap = null,
            GrossPL = null,
            TotalCost = Math.Abs( csvModel.Total)
        
        };
    }

    private async Task<ProductEntity?> GetOrCreateProduct(string symbol, string name, string isin, string echange)
    {
        if (echange.IsNullOrWhiteSpace())
        {
            return null;
        }
        
        var product = await transactionContext.Products
                                              .FirstOrDefaultAsync(p => p.Symbol == symbol);

        if (product == null)
        {
            product = new ProductEntity
            {
                Symbol = symbol,
                Name = name,
                ISIN = isin,
                ProviderIdentificator = isin
            };

            if (!string.IsNullOrEmpty(isin) || !string.IsNullOrEmpty(name))
            {
                try
                {
                    // Najdi MIC kód podle venue z Degiro
                    string mic = null;
                    if (!string.IsNullOrEmpty(echange) && DegiroMicToOpenFigiExchangeCode.TryGetValue(echange, out var mappedMic))
                    {
                        if (product.Name.Contains("ETF") && mappedMic == "GY" )
                        {
                            mappedMic = "GT";
                        }
                        mic = mappedMic;
                    }

                    var result = await GetTickerFromIsin(isin, mic);
                    AlphaData.alphaVantageData.TryGetValue(echange, out var alphaVantageData);

                    var symbolSearchMatch = await GetSymbolOverviewONalphaAsync(result + alphaVantageData.Suffix);

                    if (symbolSearchMatch is null)
                    {
                        symbolSearchMatch = await GetSymbolOverviewONalphaAsync(name);

                        decimal.TryParse(symbolSearchMatch?.MatchScore, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal matchScore);
                        
                        if (symbolSearchMatch is not null && matchScore < 0.8m )
                        {
                            symbolSearchMatch = null;
                        }
                    }

                    product.Ticker =
                        symbolSearchMatch?.Symbol ?? result;
                    product.Currency = symbolSearchMatch?.Currency ?? alphaVantageData.Currency;

                    if (symbolSearchMatch is not null)
                    {
                        product.Name = symbolSearchMatch.Name;
                    }
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
    
    
    
    // --- Upraveno: použití OpenFIGI Refit klienta ---
    private async Task<string> GetTickerFromIsin(string isin, string exchange)
    {
        try
        {
            
            
            var jobs = new List<FigiJob>
            {
                new FigiJob
                {
                    IdType = "ID_ISIN",
                    IdValue = isin,
                    // Pokud máme MIC, přidej jej jako ExchangeCode
                   ExchangeCode = string.IsNullOrEmpty(exchange) ? null : exchange
                }
            };

            List < FigiMappingResultContainer > response = new();
            try
            {
                 response = await openFigiApi.MapAsync(jobs);

            }
            catch (Exception e)
            {
                 jobs = new List<FigiJob>
                {
                    new FigiJob
                    {
                        IdType = "ID_ISIN",
                        IdValue = isin,
                        // Pokud máme MIC, přidej jej jako ExchangeCode
                        ExchangeCode = "XA"
                    }
                };
                
                 response = await openFigiApi.MapAsync(jobs);
            }
            if (response == null || response.Count == 0 || response[0].Data == null || response[0].Data.Count == 0)
            {
                return ("No ticker found");
            }

            // Najdi ticker podle burzy (exchange)
            var dataList = response[0].Data;
            
            // Pokud není shoda podle burzy, vrať první dostupný ticker
            var firstTicker = dataList.FirstOrDefault(d => !string.IsNullOrEmpty(d.Ticker));
            return firstTicker?.Ticker ?? "Unknown";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching ticker for ISIN {isin} on {exchange}: {ex.Message}");

            return ("Error");
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

internal class TransactionCsvModel
{
    [Name("Datum")]
    public string DateString { get; set; }

    public DateTime Date => DateTime.ParseExact(DateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);

    [Name("Čas")]
    public string Time { get; set; }

    [Name("Produkt")]
    public string Product { get; set; }

    [Name("ISIN")]
    public string ISIN { get; set; }

    [Name("Reference")]
    public string Reference { get; set; }

    [Name("Venue")]
    public string Exchange { get; set; }

    [Name("Počet")]
    public string QuantityString { get; set; }

    public decimal Quantity => decimal.TryParse(QuantityString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value)
        ? value
        : 0;

    [Name("Cena")]
    public string PriceString { get; set; }

    public decimal Price =>
        decimal.TryParse(PriceString.Split(',')[0], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value)
            ? value
            : 0;

    [Name("Hodnota v domácí měně")]
    public string LocalValueString { get; set; }

    public decimal LocalValue => decimal.TryParse(LocalValueString.Split(',')[0], NumberStyles.Any,
                                                  CultureInfo.InvariantCulture, out decimal value)
        ? value
        : 0;

    [Name("Hodnota")]
    public string ValueString { get; set; }

    public decimal Value =>
        decimal.TryParse(ValueString.Split(',')[0], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value)
            ? value
            : 0;

    [CsvHelper.Configuration.Attributes.Index(13)]
    public string ValueCurreny { get; set; }

    [Name("Směnný kurz")]
    public string ExchangeRateString { get; set; }

    public decimal ExchangeRate =>
        decimal.TryParse(ExchangeRateString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value)
            ? value
            : 1;

    [Name("Transaction and/or third")]
    public string TransactionFeeString { get; set; }

    public decimal TransactionFee => decimal.TryParse(TransactionFeeString.Split(',')[0], NumberStyles.Any,
                                                      CultureInfo.InvariantCulture, out decimal value)
        ? Math.Abs(value)
        : 0;

    [CsvHelper.Configuration.Attributes.Index(15)]
    public string TransactionFeeCurreny { get; set; }

    [Name("Celkem")]
    public string TotalString { get; set; }

    public decimal Total =>
        decimal.TryParse(TotalString.Split(',')[0], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value)
            ? value
            : 0;

    [CsvHelper.Configuration.Attributes.Index(17)]
    public string TotalCurreny { get; set; }
}

