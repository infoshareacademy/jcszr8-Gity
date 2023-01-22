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

    public float GetPowerinKM()
    {
        // TODO
        // Horse Power - konie mechaniczne; 1KM=735,49875W=0,9863 HP; 1kW = 1.36KM
        return 0.0f;
    }
}
