namespace Stockino3.Services;

public enum ProductType
{
    Equity, // Akcie
    Fund, // ETF, podílové fondy apod.
    Cryptocurrency, // Kryptoměny (např. Bitcoin)
    Commodity, // Komodity (např. zlato)
    FiatCurrency, // Fiat měny (např. USD, EUR)
    Bond // Dluhopisy
}

public class ProductEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string? ISIN { get; set; }
    public string? Ticker { get; set; }
    public string Currency { get; set; }
    public string ProviderIdentificator { get; set; }
    public ProductType Type { get; set; }
    public ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
}
