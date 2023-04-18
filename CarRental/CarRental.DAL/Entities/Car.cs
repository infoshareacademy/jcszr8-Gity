using CarRental.DAL.Entities.BaseEntity;
using CommonLibrary.Enums;
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
    public string? Color { get; set; }
    public TransmissionType? Transmission { get; set; }

    [JsonProperty("licence_plate_number")]
    public string LicencePlateNumber { get; set; }   
    public int? Kilometrage { get; set; }
    [JsonProperty("power_kw")]
    public float? PowerInKiloWats { get; set; }
    [JsonProperty("fuel_type")]
    public EngineType EngineType { get; set; }
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

    private static List<string> _availableAddons = new() { "Ac", "towbar", "ABS", "roof rack" };
    //public static List<string> GetAvailableAddons() { return _availableAddons; }

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

    public Car FillModel(Car car)
    {
        Make = car.Make;
        CarModelProp = car.CarModelProp;
        Year = car.Year;
        LicencePlateNumber = car.LicencePlateNumber;

        Kilometrage = car.Kilometrage;
        Doors = car.Doors;
        Price = car.Price;
        Airbags = car.Airbags;
        SeatsNo = car.SeatsNo;
        Color = car.Color;
        Transmission = car.Transmission;
        FuelConsumption = car.FuelConsumption;
        Displacement = car.Displacement;
        EngineType = car.EngineType;
        PowerInKiloWats = car.PowerInKiloWats;


        Addons = car.Addons;
        return this;
    }
}
