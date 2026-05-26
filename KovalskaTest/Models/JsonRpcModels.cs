using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

/// <summary>
/// DTO для API
/// </summary>
public class JsonRpcRequest
{
    public string Jsonrpc { get; init; } = "2.0";
    public string Method { get; init; } = "TestMonitoringPlan";
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public object Params { get; init; }
}

public class ApiResponse
{
    [JsonPropertyName("result")]
    public ApiResult Result { get; set; }
}

public class ApiResult
{
    [JsonPropertyName("TechnicalPlaces")]
    public List<TechnicalPlace> TechnicalPlaces { get; set; } = new();
}