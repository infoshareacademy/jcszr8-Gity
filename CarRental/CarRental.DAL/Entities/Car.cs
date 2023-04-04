using CarRental.DAL.Entities.BaseEntity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.DAL.Entities;
public class Car : Entity
{
    public Car() {
        if (_addonHelper != null)
        {
            this.Addons = string.Join(";", _addonHelper);
        }
        else
            this.Addons = "";
    }

    [JsonProperty("addons")]
    private List<string> _addonHelper;

    #region Properties/Fields

    //[JsonProperty(PropertyName = "model")]
    [JsonProperty("model")]
    public string CarModelProp { get; set; }

    public string Make { get; set; }

    // TODO fix end year
    [Range(2000, 2050, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Year { get; set; } // production year

    public string? Color { get; set; }

    public string? Transmission { get; set; }

    [JsonProperty("licence_plate_number")]
    public string LicencePlateNumber { get; set; }

    [Range(0, 500_000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Kilometrage { get; set; }

    [JsonProperty("power_kw")]
    public float? PowerInKiloWats { get; set; }

    [JsonProperty("fuel_type")]
    public string? EngineType { get; set; }

    [JsonProperty("displacement")]
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.

    [Range(3, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Doors { get; set; }

    [JsonProperty("max_capacity")]
    [Range(2, 50,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? SeatsNo { get; set; } // total number of seats (with driver seat included)

    [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    [MaxLength(5)]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"

    public string Addons { get; set; }

    [Range(100, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public decimal? Price { get; set; }

    private static List<string> _availableAddons = new() { "Ac", "towbar", "ABS", "roof rack" };

    public static List<string> GetAvailableAddons() { return _availableAddons; }

    #endregion

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
        //Color = car.Color;
        Transmission = car.Transmission;
        FuelConsumption = car.FuelConsumption;
        Displacement = car.Displacement;
        return this;
    }
}
