namespace CarRental.Logic.Models;
public class CarTempViewModel
{
    public int Id { get; set; }
    public string? CarModelProp { get; set; }
    public List<string> Addons { get; set; } = new();
}
