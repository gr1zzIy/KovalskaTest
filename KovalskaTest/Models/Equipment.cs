namespace KovalskaTest.Models;

public class Equipment
{
    public string Name { get; set; }
    public List<MonitoringTask> MonitoringTasks { get; set; } = new();
}