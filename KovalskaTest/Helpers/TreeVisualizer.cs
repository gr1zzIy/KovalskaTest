using KovalskaTest.Models;

namespace KovalskaTest.Helpers;

/// <summary>
/// Хелпер для візуалізації ієрархічних структур
/// </summary>
public static class TreeVisualizer
{
    /// <summary>
    /// Виводить ієрархію об'єктів у вигляді дерева 
    /// з підрахунком кількості дочірніх елементів.
    /// </summary>
    /// <param name="result">Дані отримані з API.</param>
    public static void Render(ApiResult result)
    {
        if (result?.TechnicalPlaces == null) return;

        foreach (var place in result.TechnicalPlaces)
        {
            Console.WriteLine($"{place.Name} ({place.Equipments.Count})");

            foreach (var equipment in place.Equipments)
            {
                Console.WriteLine($"    {equipment.Name} ({equipment.MonitoringTasks.Count})");

                foreach (var task in equipment.MonitoringTasks)
                {
                    Console.WriteLine($"        {task.CharacteristicName}");
                }
            }
        }
    }
}