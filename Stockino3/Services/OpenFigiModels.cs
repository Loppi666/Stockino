using System.Text.Json.Serialization;

namespace Stockino3.Services;

public class FigiJob
{
    [JsonPropertyName("idType")]
    public string IdType { get; set; }

    [JsonPropertyName("idValue")]
    public string IdValue { get; set; }
    
    [JsonPropertyName("exchCode")]
    public string ExchangeCode { get; set; }
}

public class FigiMappingResultContainer
{
    [JsonPropertyName("data")]
    public List<FigiInstrumentData> Data { get; set; }

    [JsonPropertyName("error")]
    public FigiError Error { get; set; }

    [JsonPropertyName("warning")]
    public FigiError Warning { get; set; }
}

public class FigiInstrumentData
{
    [JsonPropertyName("figi")]
    public string Figi { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("ticker")]
    public string Ticker { get; set; }

    [JsonPropertyName("exchCode")]
    public string ExchCode { get; set; }

    [JsonPropertyName("compositeFIGI")]
    public string CompositeFigi { get; set; }

    [JsonPropertyName("securityType")]
    public string SecurityType { get; set; }

    [JsonPropertyName("marketSector")]
    public string MarketSector { get; set; }

    [JsonPropertyName("securityDescription")]
    public string SecurityDescription { get; set; }

    [JsonPropertyName("securityType2")]
    public string SecurityType2 { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class FigiError
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}
