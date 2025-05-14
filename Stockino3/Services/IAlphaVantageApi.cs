using System.Text.Json.Serialization;
using Refit;

namespace Stockino3.Services;

public interface IAlphaVantageApi
{
    [Get("/query?function=CURRENCY_EXCHANGE_RATE&from_currency={fromCurrency}&to_currency={toCurrency}")]
    Task<ExchangeRateResponse> GetExchangeRateAsync(string fromCurrency, string toCurrency);

    [Get("/query?function=OVERVIEW&symbol={symbol}")]
    Task<SymbolOverview> GetOverviewAsync(string symbol);

    [Get("/query?function=SYMBOL_SEARCH&keywords={keywords}")]
    Task<SymbolSearchResult> SearchSymbolAsync(string keywords);
}

public class ExchangeRateResponse
{
    [JsonPropertyName("Realtime Currency Exchange Rate")]
    public ExchangeRateRealtimeData RealtimeCurrencyExchangeRate { get; set; }
}

public class ExchangeRateRealtimeData
{
    [JsonPropertyName("5. Exchange Rate")]
    public string ExchangeRate { get; set; }
}

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
    // ... další pole dle potřeby ...
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
    
    [JsonPropertyName("9. matchScore")]
    public string MatchScore { get; set; }
}
