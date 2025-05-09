using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Stockino3.Services;
using Microsoft.EntityFrameworkCore;

// Model pro mapování CSV řádku AnyCoin
public class AnyCoinCsvRow
{
    [Name("Date")]
    public DateTime Date { get; set; }

    [Name("Type")]
    public string Type { get; set; }

    [Name("Amount")]
    public double Amount { get; set; }

    [Name("Currency")]
    public string Currency { get; set; }

    [Name("Order ID")]
    public string OrderId { get; set; }
}

public class AnyCoinTransactionLoader
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
            var currency = row.Currency?.Trim();
            var amount = row.Amount;
            var type = row.Type?.Trim();
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
                    Currency = currency,// Přidáno nastavení Symbolu
                    Type =
                        CryptocurrencyList.GetAll().Any(c => c.Symbol == currency)
                            ? ProductType.Cryptocurrency
                            : (CurrencyList.GetAll().Any(f => f.Code == currency)
                                ? ProductType.FiatCurrency
                                : ProductType.Equity),  
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
                Currency = currency,
                Price = 0,
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

public static class CurrencyList
{
    public static List<Currency> GetAll()
    {
        return new List<Currency>
        {
            new("AED", "United Arab Emirates Dirham", "د.إ", "United Arab Emirates"),
            new("AFN", "Afghan Afghani", "؋", "Afghanistan"),
            new("ALL", "Albanian Lek", "L", "Albania"),
            new("AMD", "Armenian Dram", "֏", "Armenia"),
            new("ANG", "Netherlands Antillean Guilder", "ƒ", "Netherlands Antilles"),
            new("AOA", "Angolan Kwanza", "Kz", "Angola"),
            new("ARS", "Argentine Peso", "$", "Argentina"),
            new("AUD", "Australian Dollar", "$", "Australia"),
            new("AWG", "Aruban Florin", "ƒ", "Aruba"),
            new("AZN", "Azerbaijani Manat", "₼", "Azerbaijan"),
            new("BAM", "Bosnia-Herzegovina Convertible Mark", "KM", "Bosnia and Herzegovina"),
            new("BBD", "Barbadian Dollar", "$", "Barbados"),
            new("BDT", "Bangladeshi Taka", "৳", "Bangladesh"),
            new("BGN", "Bulgarian Lev", "лв", "Bulgaria"),
            new("BHD", "Bahraini Dinar", ".د.ب", "Bahrain"),
            new("BIF", "Burundian Franc", "FBu", "Burundi"),
            new("BMD", "Bermudian Dollar", "$", "Bermuda"),
            new("BND", "Brunei Dollar", "$", "Brunei"),
            new("BOB", "Bolivian Boliviano", "Bs.", "Bolivia"),
            new("BRL", "Brazilian Real", "R$", "Brazil"),
            new("BSD", "Bahamian Dollar", "$", "Bahamas"),
            new("BTN", "Bhutanese Ngultrum", "Nu.", "Bhutan"),
            new("BWP", "Botswana Pula", "P", "Botswana"),
            new("BYN", "Belarusian Ruble", "Br", "Belarus"),
            new("BZD", "Belize Dollar", "$", "Belize"),
            new("CAD", "Canadian Dollar", "$", "Canada"),
            new("CDF", "Congolese Franc", "FC", "Democratic Republic of the Congo"),
            new("CHF", "Swiss Franc", "CHF", "Switzerland"),
            new("CLP", "Chilean Peso", "$", "Chile"),
            new("CNY", "Chinese Yuan", "¥", "China"),
            new("COP", "Colombian Peso", "$", "Colombia"),
            new("CRC", "Costa Rican Colón", "₡", "Costa Rica"),
            new("CUP", "Cuban Peso", "$", "Cuba"),
            new("CVE", "Cape Verdean Escudo", "$", "Cape Verde"),
            new("CZK", "Czech Koruna", "Kč", "Czech Republic"),
            new("DJF", "Djiboutian Franc", "Fdj", "Djibouti"),
            new("DKK", "Danish Krone", "kr", "Denmark"),
            new("DOP", "Dominican Peso", "$", "Dominican Republic"),
            new("DZD", "Algerian Dinar", "د.ج", "Algeria"),
            new("EGP", "Egyptian Pound", "£", "Egypt"),
            new("ERN", "Eritrean Nakfa", "Nkf", "Eritrea"),
            new("ETB", "Ethiopian Birr", "Br", "Ethiopia"),
            new("EUR", "Euro", "€", "Eurozone"),
            new("FJD", "Fijian Dollar", "$", "Fiji"),
            new("FKP", "Falkland Islands Pound", "£", "Falkland Islands"),
            new("FOK", "Faroese Króna", "kr", "Faroe Islands"),
            new("GBP", "British Pound", "£", "United Kingdom"),
            new("GEL", "Georgian Lari", "₾", "Georgia"),
            new("GHS", "Ghanaian Cedi", "₵", "Ghana"),
            new("GIP", "Gibraltar Pound", "£", "Gibraltar"),
            new("GMD", "Gambian Dalasi", "D", "Gambia"),
            new("GNF", "Guinean Franc", "FG", "Guinea"),
            new("GTQ", "Guatemalan Quetzal", "Q", "Guatemala"),
            new("GYD", "Guyanese Dollar", "$", "Guyana"),
            new("HKD", "Hong Kong Dollar", "$", "Hong Kong"),
            new("HNL", "Honduran Lempira", "L", "Honduras"),
            new("HRK", "Croatian Kuna", "kn", "Croatia"),
            new("HTG", "Haitian Gourde", "G", "Haiti"),
            new("HUF", "Hungarian Forint", "Ft", "Hungary"),
            new("IDR", "Indonesian Rupiah", "Rp", "Indonesia"),
            new("ILS", "Israeli New Shekel", "₪", "Israel"),
            new("INR", "Indian Rupee", "₹", "India"),
            new("IQD", "Iraqi Dinar", "ع.د", "Iraq"),
            new("IRR", "Iranian Rial", "﷼", "Iran"),
            new("ISK", "Icelandic Króna", "kr", "Iceland"),
            new("JMD", "Jamaican Dollar", "$", "Jamaica"),
            new("JOD", "Jordanian Dinar", "د.ا", "Jordan"),
            new("JPY", "Japanese Yen", "¥", "Japan"),
            new("KES", "Kenyan Shilling", "Sh", "Kenya"),
            new("KGS", "Kyrgyzstani Som", "с", "Kyrgyzstan"),
            new("KHR", "Cambodian Riel", "៛", "Cambodia"),
            new("KMF", "Comorian Franc", "CF", "Comoros"),
            new("KPW", "North Korean Won", "₩", "North Korea"),
            new("KRW", "South Korean Won", "₩", "South Korea"),
            new("KWD", "Kuwaiti Dinar", "د.ك", "Kuwait"),
            new("KYD", "Cayman Islands Dollar", "$", "Cayman Islands"),
            new("KZT", "Kazakhstani Tenge", "₸", "Kazakhstan"),
            new("LAK", "Laotian Kip", "₭", "Laos"),
            new("LBP", "Lebanese Pound", "ل.ل", "Lebanon"),
            new("LKR", "Sri Lankan Rupee", "Rs", "Sri Lanka"),
            new("LRD", "Liberian Dollar", "$", "Liberia"),
            new("LSL", "Lesotho Loti", "L", "Lesotho"),
            new("LYD", "Libyan Dinar", "ل.د", "Libya"),
            new("MAD", "Moroccan Dirham", "د.م.", "Morocco"),
            new("MDL", "Moldovan Leu", "L", "Moldova"),
            new("MGA", "Malagasy Ariary", "Ar", "Madagascar"),
            new("MKD", "Macedonian Denar", "ден", "North Macedonia"),
            new("MMK", "Myanma Kyat", "K", "Myanmar"),
            new("MNT", "Mongolian Tögrög", "₮", "Mongolia"),
            new("MOP", "Macanese Pataca", "P", "Macau"),
            new("MRU", "Mauritanian Ouguiya", "UM", "Mauritania"),
            new("MUR", "Mauritian Rupee", "₨", "Mauritius"),
            new("MVR", "Maldivian Rufiyaa", "Rf", "Maldives"),
            new("MWK", "Malawian Kwacha", "MK", "Malawi"),
            new("MXN", "Mexican Peso", "$", "Mexico"),
            new("MYR", "Malaysian Ringgit", "RM", "Malaysia"),
            new("MZN", "Mozambican Metical", "MT", "Mozambique")
        };
    }
}
