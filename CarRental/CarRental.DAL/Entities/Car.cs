using CarRental.Common.Enums;
using CarRental.DAL.Entities.BaseEntity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities;
public class Car : Entity
{

    [JsonProperty("addons")]
    private List<string> _addonHelper = new();

    #region Properties/Fields

    [JsonProperty("model")]
    public string CarModelProp { get; set; }
    public string Make { get; set; }
    public int Year { get; set; } // production year

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
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.

    public int? Doors { get; set; }

    [JsonProperty("max_capacity")]
    public int? SeatsNo { get; set; }
    public int? Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"
    public string? Addons { get; set; }
    public decimal? Price { get; set; }

    #endregion

    public void PopulateAddonsFromAddonHelper()
    {
        if (_addonHelper != null)
        {
            this.Addons = string.Join(";", _addonHelper);
        }
        else
            this.Addons = string.Empty;
    }
}
