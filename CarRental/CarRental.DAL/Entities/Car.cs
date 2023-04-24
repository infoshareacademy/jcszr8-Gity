using CarRental.Common.Enums;
using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Entities;
public class Car : Entity
{
    public string CarModelProp { get; set; }
    public string Make { get; set; }
    public int Year { get; set; }
    public string LicencePlateNumber { get; set; }
    public EngineType? EngineType { get; set; }
    public TransmissionType? Transmission { get; set; }
    public string? Addons { get; set; }
    public string? Color { get; set; }
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.
    public string? FuelConsumption { get; set; }
    public int? Kilometrage { get; set; }
    public int? Doors { get; set; }
    public int? SeatsNo { get; set; }
    public int? Airbags { get; set; }
    public float? PowerInKiloWats { get; set; }
    public decimal? Price { get; set; }
}
