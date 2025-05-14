using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Stockino3;
using Stockino3.Services;

// Model pro mapování CSV řádku AnyCoin
public class AnyCoinCsvRow
{
    [Name("Date")]
    public DateTime Date { get; set; }

    [Name("Type")]
    public string Type { get; set; }

    [Name("Amount")]
    public decimal Amount { get; set; }

    [Name("Currency")]
    public string Currency { get; set; }

    [Name("Order ID")]
    public string OrderId { get; set; }
}

public class AnyCoinTransactionLoader : IService
{
    private readonly TransactionContext db;

    public AnyCoinTransactionLoader(TransactionContext db)
    {
        this.db = db;
    }

    /// <summary>
    /// Načte transakce z AnyCoin CSV řetězce ve formátu:
    /// Date,Type,Amount,Currency,Order ID
    /// </summary>
    public async ValueTask ImportFromCsv(string path)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            HasHeaderRecord = true,
            MissingFieldFound = null
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);

        var records = csv.GetRecords<AnyCoinCsvRow>();

        var result = new List<TransactionEntity>();

        foreach (var row in records)
        {
            string? currency = row.Currency?.Trim();
            decimal amount = row.Amount;
            string? type = row.Type?.Trim();
            var date = row.Date;

            // Najdi existující produkt podle názvu (měny)
            var product = await db.Set<ProductEntity>().FirstOrDefaultAsync(p => p.Name == currency);

            if (product == null)
            {
                product = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = currency,
                    Symbol = currency,
                    Currency = currency, // Přidáno nastavení Symbolu
                    Type =
                        CryptocurrencyList.GetAll().Any(c => c.Symbol == currency)
                            ? ProductType.Cryptocurrency
                            : CurrencyList.GetAll().Any(f => f.Code == currency)
                                ? ProductType.FiatCurrency
                                : ProductType.Equity
                };

                db.Set<ProductEntity>().Add(product);
                await db.SaveChangesAsync();
            }

            var entity = new TransactionEntity
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Product = product,
                ExecutionTime = date,
                BuyInCurrency = currency,
                UnitPrice = 0,
                Volume = amount,
                Margin = null,
                Commission = null,
                Swap = null,
                GrossPL = null,
                OperationType = MapAnyCoinType(type)
            };

            db.Set<TransactionEntity>().Add(entity);
        }

        await db.SaveChangesAsync();
    }

    private static OperationType MapAnyCoinType(string type)
    {
        switch (type.ToLowerInvariant())
        {
            case "deposit":
                return OperationType.OPEN;
            case "trade payment":
            case "trade fill":
                return OperationType.CLOSE;
            default:
                return OperationType.OPEN;
        }
    }
}

public class Cryptocurrency
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // Např. "Top", "Stablecoin", "Meme", atd.
    public decimal? MarketCapUsd { get; set; } // Nepovinné

    public Cryptocurrency(string symbol, string name, string category, decimal? marketCapUsd = null)
    {
        Symbol = symbol;
        Name = name;
        Category = category;
        MarketCapUsd = marketCapUsd;
    }

    public override string ToString()
    {
        return $"{Name} ({Symbol}) - {Category}" +
               (MarketCapUsd.HasValue
                   ? $" | Market Cap: ${MarketCapUsd.Value:N0}"
                   : "");
    }
}

public static class CryptocurrencyList
{
    public static List<Cryptocurrency> GetAll()
    {
        return new List<Cryptocurrency>
        {
            new("BTC", "Bitcoin", "Top"),
            new("ETH", "Ethereum", "Top"),
            new("BNB", "Binance Coin", "Top"),
            new("SOL", "Solana", "Top"),
            new("XRP", "XRP", "Top"),
            new("ADA", "Cardano", "Top"),
            new("AVAX", "Avalanche", "Top"),
            new("DOGE", "Dogecoin", "Meme"),
            new("DOT", "Polkadot", "Top"),
            new("LINK", "Chainlink", "Top"),

            new("USDT", "Tether", "Stablecoin"),
            new("USDC", "USD Coin", "Stablecoin"),
            new("DAI", "Dai", "Stablecoin"),
            new("TUSD", "TrueUSD", "Stablecoin"),
            new("USDP", "Pax Dollar", "Stablecoin"),

            new("LTC", "Litecoin", "Other"),
            new("XMR", "Monero", "Privacy"),
            new("UNI", "Uniswap", "DeFi"),
            new("AAVE", "Aave", "DeFi"),
            new("ATOM", "Cosmos", "Other"),
            new("GRT", "The Graph", "Other"),
            new("ARB", "Arbitrum", "Layer2"),
            new("OP", "Optimism", "Layer2"),
            new("RNDR", "Render", "Other")
        };
    }
}

public class Currency
{
    public string Code { get; set; } // Např. "USD"
    public string Name { get; set; } // Např. "United States Dollar"
    public string Symbol { get; set; } // Např. "$"
    public string Region { get; set; } // Např. "United States"

    public Currency(string code, string name, string symbol, string region)
    {
        Code = code;
        Name = name;
        Symbol = symbol;
        Region = region;
    }

    public override string ToString()
    {
        return $"{Name} ({Code}) - {Region} | Symbol: {Symbol}";
    }
}
