using System.Text.Json.Serialization;

namespace KovalskaTest.Models;

public class ApiResponse
{
    [JsonPropertyName("result")]
    public ApiResult Result { get; set; }
}