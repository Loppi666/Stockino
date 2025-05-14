using System.Collections.Concurrent;
using System.Globalization;
using System.Text.Json;

namespace Stockino3.Services;

public class ExchangeRateService : IService
{
    public const string AlphaApiKey = "9E71JJDSQDAD5CZR";

    private static readonly HttpClient client = new();

    // Cache bude obsahovat celý JSON response pro dvojici měn
    private static readonly ConcurrentDictionary<string, JsonElement> _responseCache = new();

    public async Task<double?> GetHistoricalExchangeRateAsync(string fromCurrency, string toCurrency, DateTime date)
    {
        string cacheKey = $"{fromCurrency}_{toCurrency}";
        JsonElement timeSeries;

        // Zkusíme najít response v cache
        if (!_responseCache.TryGetValue(cacheKey, out var cachedRoot))
        {
            string url = $"https://www.alphavantage.co/query?function=FX_DAILY&from_symbol={fromCurrency}&to_symbol={toCurrency}&apikey={AlphaApiKey}&outputsize=full";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement.Clone(); // Clone kvůli uložení do cache

            if (!root.TryGetProperty("Time Series FX (Daily)", out timeSeries))
            {
                return null;
            }

            _responseCache.TryAdd(cacheKey, root);
            cachedRoot = root;
        }

        // Pokud jsme v cache, nebo jsme právě uložili, získáme Time Series
        if (!cachedRoot.TryGetProperty("Time Series FX (Daily)", out timeSeries))
        {
            return null;
        }

        string dateKey = date.ToString("yyyy-MM-dd");

        if (!timeSeries.TryGetProperty(dateKey, out var dayData))
        {
            return null;
        }

        if (dayData.TryGetProperty("4. close", out var closePrice))
        {
            if (double.TryParse(closePrice.GetString(), CultureInfo.InvariantCulture, out double rate))
            {
                return rate;
            }
        }

        return null;
    }
}
