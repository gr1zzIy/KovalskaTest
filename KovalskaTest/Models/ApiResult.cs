using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

public class ApiResult
{
    [JsonPropertyName("TechnicalPlaces")]
    public List<TechnicalPlace> TechnicalPlaces { get; set; } = new();
}