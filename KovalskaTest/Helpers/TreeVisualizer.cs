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
            RenderTechnicalPlace(place, 0);
        }
    }

    private static void RenderTechnicalPlace(TechnicalPlace place, int level)
    {
        // базовий відступ, 4 пробіла на рівень
        string indent = new string(' ', level * 4);
        
        // Рахуємо кількість
        int subPlacesCount = place.SubTechnicalPlaces?.Count ?? 0;
        int equipmentsCount = place.Equipments?.Count ?? 0;
        int totalChildren = subPlacesCount + equipmentsCount;
        
        // Назва технічного місця
        Console.WriteLine($"{indent}{place.Name} ({totalChildren})");
        
        // Виводимо всі вкладені технічні місця
        if (place.SubTechnicalPlaces != null)
        {
            foreach (var subPlace in place.SubTechnicalPlaces)
            {
                RenderTechnicalPlace(subPlace, level + 1);
            }
        }
        
        // Виводимо все обладнання, що закріплене за цим місцем
        if (place.Equipments != null)
        {
            foreach (var equipment in place.Equipments)
            {
                string equipIndent = new string(' ', (level + 1) * 4);
                int tasksCount = equipment.MonitoringTasks?.Count ?? 0;

                Console.WriteLine($"{equipIndent}Equipment: {equipment.Name} ({tasksCount})");

                // Виводимо завдання для цього обладнання
                if (equipment.MonitoringTasks != null)
                {
                    for (int i = 0; i < equipment.MonitoringTasks.Count; i++)
                    {
                        var task = equipment.MonitoringTasks[i];
                        string taskIndent = new string(' ', (level + 2) * 4);
                        
                        Console.WriteLine($"{taskIndent}- Task: {task.CharacteristicName}");

                        if (i == equipment.MonitoringTasks.Count - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                    /*
                    foreach (var task in equipment.MonitoringTasks)
                    {
                        string taskIndent = new string(' ', (level + 2) * 4);

                        Console.WriteLine($"{taskIndent}- Task: {task.CharacteristicName}");
                    }
                    */
                }
            }
        }
    }
}