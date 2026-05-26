namespace KovalskaTest.Models;

public class TechnicalPlace
{
    public string Name { get; set; }
    public List<Equipment> Equipments { get; set; } = new();
}