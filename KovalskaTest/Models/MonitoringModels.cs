using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

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

public class TechnicalPlace
{
    public string Name { get; set; }
    public List<Equipment> Equipments { get; set; } = new();
}

public class Equipment
{
    public string Name { get; set; }
    public List<MonitoringTask> MonitoringTasks { get; set; } = new();
}

public class MonitoringTask
{
    [JsonPropertyName("CharacteristicName")]
    public string CharacteristicName { get; set; }
}

public class JsonRpcRequest
{
    public string Jsonrpc { get; init; } = "2.0";
    public string Method { get; init; } = "TestMonitoringPlan";
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public object Params { get; init; }
}