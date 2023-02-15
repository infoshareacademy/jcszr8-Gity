using Newtonsoft.Json;
using System.Text;

namespace CarRental.DAL.Models;
public sealed class Car
{
    public int Id { get; set; }

    [JsonProperty(PropertyName = "model")]
    public string? CarModel { get; set; }

    public string? Make { get; set; }

    public int Year { get; set; } // production year

    public string? Color { get; set; }

    public string? Transmission { get; set; }

    [JsonProperty("licence_plate_number")]
    public string? LicencePlateNumber { get; set; } // numer rejestracyjny pojazdu

    public int Kilometrage { get; set; }

    [JsonProperty("engine_parameters")]
    public EngineParameters? EngineParameters { get; set; }

    public int Doors { get; set; }

    [JsonProperty("max_capacity")]
    public int SeatsNo { get; set; } // total number of seats (with driver seat included)

    public int Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"

    public List<string> Addons { get; set; } = new();

    public decimal Price { get; set; }

    public Car(int id, string make, string model, string licensePlate)
    {
        Id = id;
        Make = make;
        CarModel = model;
        LicencePlateNumber = licensePlate;
    }

    public override string ToString()
    {
        return $"id:{Id} | {Make} | {CarModel} | {LicencePlateNumber} | {GetAddonsToString()}";
    }

    public string GetDetails()
    {
        var year = Year.ToString() ?? "-";
        var color = Color?.ToString() ?? "-";
        var transmission = Transmission?.ToString() ?? "-";
        var engineType = EngineParameters?.Type.ToString() ?? "-";
        var engineDisplacement = EngineParameters?.Displacement?.ToString() ?? "-";
        var enginePowerKw = EngineParameters?.PowerInKiloWats.ToString() ?? "-";
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
EngineParameters: {engineType}, {engineDisplacement}, {enginePowerKw}
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
}
