using CarRental.DAL.Entities.BaseEntity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.DAL.Models;
public sealed class Car : Entity
{
    #region Properties/Fields

    [JsonProperty(PropertyName = "model")]
    [Display(Name = "Model")]
    [Required]
    public string CarModel { get; set; }

    [MaxLength(100)]
    [Required]
    public string Make { get; set; }

    // TODO fix end year
    [Range(2000, 2050,
       ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Year { get; set; } // production year

    [MaxLength(20)]
    public string? Color { get; set; }

    [MaxLength(20)]
    public string? Transmission { get; set; }

    [JsonProperty("licence_plate_number")]
    [Display (Name = "Licence Plate")]
    [Required]
    [MaxLength(8)]
    public string LicencePlateNumber { get; set; }

    [Range(0, 500_000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Kilometrage { get; set; }

    [JsonProperty("power_kw")]
    [Display (Name = "Power in kWs")]
    public float? PowerInKiloWats { get; set; }

    [JsonProperty("fuel_type")]
    [Display (Name = "Engine Type")]
    public string? EngineType { get; set; }

    [JsonProperty("displacement")]
    [MaxLength(10)]
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.

    [Range(3, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Doors { get; set; }

    [JsonProperty("max_capacity")]
    [Display (Name = "No. of Seats")]
    [Range(2, 50,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? SeatsNo { get; set; } // total number of seats (with driver seat included)

    [Display (Name = "No. of Airbags")]
    [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    [Display (Name = "Fuel Consumption")]
    [MaxLength(5)]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"

    [Display (Name = "Addons")]
    public List<string> Addons { get; set; } = new();

    [Range(100,1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [Display (Name = "Price/day")]
    public decimal? Price { get; set; }

    private static List<string> _availableAddons = new() { "Ac", "towbar", "ABS", "roof rack" };

    public static List<string> GetAvailableAddons() { return _availableAddons; }

    #endregion

    public Car(int id, string make, string model, string licensePlate)
    {
        Id = id;
        Make = make;
        CarModel = model;
        LicencePlateNumber = licensePlate;
    }

    public Car() { }

    public override string ToString()
    {
        return $"id:{Id} | {Make} | {CarModel} | {LicencePlateNumber} | {GetAddonsToString()}";
    }

    public string GetDetails()
    {
        var year = Year.ToString() ?? "-";
        var color = Color?.ToString() ?? "-";
        var transmission = Transmission?.ToString() ?? "-";
        var engineType = EngineType?.ToString() ?? "-";
        var engineDisplacement = Displacement?.ToString() ?? "-";
        var enginePowerKw = PowerInKiloWats.ToString() ?? "-";
        var seats = SeatsNo.ToString() ?? "-";
        var airbags = Airbags.ToString() ?? "-";
        var kilometrage = Kilometrage.ToString() ?? "-";
        var doors = Doors.ToString() ?? "-";
        var fuelConsumption = FuelConsumption?.ToString() ?? "-";
        var price = Price.ToString() ?? "-";

        return @$"Id: {Id}
Make: {Make}
Model: {CarModel}
License plate: {LicencePlateNumber}
Year: {year}
Color: {color}
Transmission: {transmission}
EngineType: {engineType}
EngineDisplacement: {engineDisplacement}
EnginePowerKw: {enginePowerKw}
Seats:{seats}
Airbags: {airbags}
Kilometrage: {kilometrage}
Doors: {doors}
Fuel consumption: {fuelConsumption}
Price: {price}
Addons: {GetAddonsToString()}
";
    }

    public string GetAddonsToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in Addons)
        {
            sb.AppendJoin(';', item.ToString());
            sb.Append('\u002C');
        }
        return sb.ToString();
    }

    public static int[] ParseIndexes(string indexesString)
    {
        char[] separators = { ',', ' ', '\t' };
        int[] ints;
        try
        {
            var strings = indexesString.Split(separators);
            ints = Array.ConvertAll(strings, s => int.Parse(s) - 1);

            Console.WriteLine();
            return ints;
        }
        catch (Exception)
        {
            return new int[] { };
        }
    }

    public void AddAddon(int index)
    {
        string addon = _availableAddons[index];
        this.Addons.Add(addon);
    }

    public void RemoveAddon(int index)
    {
        try
        {
            this.Addons.RemoveAt(index);
        }
        catch (Exception)
        {

        }
    }

    public string AddonsToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string addon in Addons)
        {
            sb.Append(addon);
            sb.Append(", ");
        }
        return sb.ToString();
    }
}
