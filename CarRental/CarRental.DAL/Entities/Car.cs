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
    [Display(Name = "Model")]
    [Required]
    public string CarModelProp { get; set; }

    [MaxLength(100)]
    [Required]
    public string Make { get; set; }

    // TODO fix end year
    [Range(2000, 2050, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Year { get; set; } // production year

    [MaxLength(20)]
    public string? Color { get; set; }

    [MaxLength(20)]
    public string? Transmission { get; set; }

    [JsonProperty("licence_plate_number")]
    [Display(Name = "Licence Plate")]
    [Required]
    [MaxLength(8)]
    public string LicencePlateNumber { get; set; }

    [Range(0, 500_000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Kilometrage { get; set; }

    [JsonProperty("power_kw")]
    [Display(Name = "Power in kWs")]
    public float? PowerInKiloWats { get; set; }

    [JsonProperty("fuel_type")]
    [Display(Name = "Engine Type")]
    public string? EngineType { get; set; }

    [JsonProperty("displacement")]
    [MaxLength(10)]
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.

    [Range(3, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Doors { get; set; }

    [JsonProperty("max_capacity")]
    [Display(Name = "No. of Seats")]
    [Range(2, 50,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? SeatsNo { get; set; } // total number of seats (with driver seat included)

    [Display(Name = "No. of Airbags")]
    [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    [Display(Name = "Fuel Consumption")]
    [MaxLength(5)]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"

    [Display(Name = "Addons")]
    //private string _addons;
    public string Addons { get; set; }
    //{
    //    get { return _addons; }
    //    set
    //    {
    //        this._addons = string.Join(";", value);
    //    }
    //}

    [Range(100, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [Display(Name = "Price/day")]
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
        //Addons = string.Join(";", car.Addons);
        return this;
    }
}
