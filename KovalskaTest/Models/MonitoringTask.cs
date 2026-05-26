using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

public class MonitoringTask
{
    [JsonPropertyName("CharacteristicName")]
    public string CharacteristicName { get; set; }
}