using System.Net.Http.Json;
using System.Text.Json;
using KovalskaTest.Models;

namespace KovalskaTest.Services;

/// <summary>
/// Сервіс для взаємодії з API
/// Реалізує логіку отримання планів моніторингу.
/// </summary>
public class KovalskaApiService
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://it-dev.kovalska.dev/DEV_TOR/ws/api/_MOBILEDATASYNC";
    
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    public KovalskaApiService()
    {
        _httpClient = new HttpClient();
    }
    
    /// <summary>
    /// Відправляє POST-запит до API для отримання даних про ієрархію обладнання.
    /// </summary>
    /// <returns>Повертає <see cref="ApiResult"/> у разі успіху або null при виникненні помилки.</returns>
    public async Task<ApiResult?> GetMonitoringPlanAsync()
    {
        var requestBody = new JsonRpcRequest
        {
            Params = new MonitoringParams
            {
                AppId = "RAM", 
                FactoryCode = "00005"
            }
        };

        try
        {
            using var response = await _httpClient.PostAsJsonAsync(Url, requestBody, _jsonOptions);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Помилка HTTP: {response.StatusCode}");
                return null;
            }

            var data = await response.Content.ReadFromJsonAsync<ApiResponse>(_jsonOptions);
    
            return data?.Result;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Помилка підключення до мережі: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Отримано некоректний формат JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непередбачувана помилка: {ex.Message}");
        }
        
        return null;
    }
}