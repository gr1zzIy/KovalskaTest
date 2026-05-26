using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

/// <summary>
/// DTO для API
/// </summary>
public class JsonRpcRequest
{
    [JsonPropertyName("Jsonrpc")]
    public string Jsonrpc { get; init; } = "2.0";
    
    [JsonPropertyName("Method")]
    public string Method { get; init; } = "TestMonitoringPlan";
    
    [JsonPropertyName("Id")]
    public string Id { get; init; } = "0cd24fad-4422-41ad-83d8-f87bdfbe8aaa";

    [JsonPropertyName("Params")] 
    public object Params { get; init; } = default!;
}

public class MonitoringParams
{
    [JsonPropertyName("AppId")]
    public string AppId { get; set; } = "RAM";

    [JsonPropertyName("PersonnelNumber")]
    public string PersonnelNumber { get; set; } = "";

    [JsonPropertyName("FactoryCode")]
    public string FactoryCode { get; set; } = "00005";
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