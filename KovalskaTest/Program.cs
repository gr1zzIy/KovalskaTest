using KovalskaTest.Services;
using KovalskaTest.Helpers;

namespace KovalskaTest;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Отримання даних з API...\n");

        var apiService = new KovalskaApiService();
        var result = await apiService.GetMonitoringPlanAsync();

        if (result != null)
        {
            TreeVisualizer.Render(result);
        }
        else
        {
            Console.WriteLine("Дані не отримано.");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}