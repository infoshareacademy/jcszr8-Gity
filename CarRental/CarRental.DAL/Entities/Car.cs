using CarRental.Common.Enums;
using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Entities;
public class Car : Entity
{
    public string Make { get; set; }
    public string CarModelProp { get; set; }
    public int Year { get; set; }
    public string LicencePlateNumber { get; set; }
    public EngineType? EngineType { get; set; }
    public TransmissionType? Transmission { get; set; }
    public List<string> Addons { get; set; } = new();
    public CarColor? Color { get; set; }
    public string? Displacement { get; set; }
    public string? FuelConsumption { get; set; }
    public int? Kilometrage { get; set; }
    public int? Doors { get; set; }
    public int? SeatsNo { get; set; }
    public int? Airbags { get; set; }
    public float? PowerInKiloWatts { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
}
