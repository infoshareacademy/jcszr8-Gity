using CarRental.DAL.Models;

namespace CarRental.ConsoleUI;
internal record CarDto
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public string? Make { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }
    public string? Transmission { get; set; }
    public string? VIN { get; set; }
    public string? LicencePlateNumber { get; set; }
    public int Kilometrage { get; set; }
    public EngineParameters EngineParameters { get; set; }
    public int Doors { get; set; }
    public bool Ac { get; set; }
    public int SeatsNo { get; set; }
    public int Airbags { get; set; }
    public string? FuelConsumption { get; set; } 
    public List<string> Addons { get; set; } = new();
    public Pricing Pricing { get; set; } = new();
}
