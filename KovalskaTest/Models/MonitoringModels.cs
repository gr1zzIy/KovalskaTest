using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

/// <summary>
/// Моделі для плану моніторингу
/// </summary>
public class TechnicalPlace
{
    [JsonPropertyName("Name")]
    public string Name { get; set; } = default!;
    
    [JsonPropertyName("TechnicalPlaces")]
    public List<TechnicalPlace>? SubTechnicalPlaces { get; set; }

    [JsonPropertyName("Equipments")]
    public List<Equipment> Equipments { get; set; } = new();
}

public class Equipment
{
    [JsonPropertyName("Name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("MonitoringTasks")]
    public List<MonitoringTask> MonitoringTasks { get; set; } = new();
}

public class MonitoringTask
{
    [JsonPropertyName("CharacteristicName")]
    public string CharacteristicName { get; set; } = default!;
}