using CarRental.Common.Enums;
using Newtonsoft.Json;

namespace CarRental.DAL.Entities;
public class CarFromJson
{
    public string Make { get; set; }
    [JsonProperty("model")]
    public string CarModelProp { get; set; }
    public int Year { get; set; }
    [JsonProperty("licence_plate_number")]
    public string LicencePlateNumber { get; set; }
    [JsonProperty("fuel_type")]
    public EngineType? EngineType { get; set; }
    public TransmissionType? Transmission { get; set; }
    [JsonProperty("addons")]
    public List<string> Addons { get; set; } = new();
    public CarColor? Color { get; set; }
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.
    [JsonProperty("fuel_consumption")]
    public string? FuelConsumption { get; set; }
    public int? Kilometrage { get; set; }
    public int? Doors { get; set; }
    [JsonProperty("max_capacity")]
    public int? SeatsNo { get; set; }
    public int? Airbags { get; set; }
    [JsonProperty("power_kw")]
    public float? PowerInKiloWatts { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
}
