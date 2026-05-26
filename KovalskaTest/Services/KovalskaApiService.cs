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
                PersonnelNumber = "", 
                FactoryCode = "00005" 
            }
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync(Url, requestBody, new JsonSerializerOptions());
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Сервер повернув помилку: {response.StatusCode}");
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Деталі: {errorContent}");
                return null;
            }
            
            var data = await response.Content.ReadFromJsonAsync<ApiResponse>(new JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true 
            });
            
            return data?.Result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
            return null;
        }
    }
}