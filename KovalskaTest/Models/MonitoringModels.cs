using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

/// <summary>
/// Моделі для плану моніторингу
/// </summary>
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
