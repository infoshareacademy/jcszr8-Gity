using CarRental.Common.Enums;
using Newtonsoft.Json;

namespace CarRental.DAL.HelperModels;
public class CarFromJson
{
    // This class serves as middleman for Addons mapping

    [JsonProperty("model")]
    public string CarModelProp { get; set; }
    public string Make { get; set; }
    public int Year { get; set; }
    [JsonProperty("licence_plate_number")]
    public string LicencePlateNumber { get; set; }
    public string? Color { get; set; }
    public TransmissionType? Transmission { get; set; }
    public int? Kilometrage { get; set; }
    [JsonProperty("power_kw")]
    public float? PowerInKiloWats { get; set; }
    [JsonProperty("fuel_type")]
    public EngineType? EngineType { get; set; }
    [JsonProperty("displacement")]
    public string? Displacement { get; set; }
    public int? Doors { get; set; }
    [JsonProperty("max_capacity")]
    public int? SeatsNo { get; set; }
    public int? Airbags { get; set; }
    [JsonProperty("fuel_consumption")]
    public string? FuelConsumption { get; set; }
    [JsonProperty("addons")]
    public List<string> Addons { get; set; } = new();
    public decimal? Price { get; set; }
}
