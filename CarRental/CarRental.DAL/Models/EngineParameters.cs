using CarRental.DAL.Enums;
using Newtonsoft.Json;

namespace CarRental.DAL.Models;
public class EngineParameters
{
    [JsonProperty("power_kw")]
    public float PowerInKiloWats { get; set; }

    [JsonProperty("fuel_type")]
    public EngineType Type { get; set; }

    [JsonProperty("displacement")]
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.
}
