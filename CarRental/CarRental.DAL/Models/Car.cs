using Newtonsoft.Json;
using System.Text;

namespace CarRental.DAL.Models;
public sealed class Car
{
    public int Id { get; set; }

    public string? Model { get; set; }

    public string? Make { get; set; }

    public int Year { get; set; } // production year

    public string? Color { get; set; }

    public string? Transmission { get; set; }
    public string? VIN { get; set; } // Vehicle Identification Number
    [JsonProperty("licence_plate_number")]
    public string? LicencePlateNumber { get; set; } // numer rejestracyjny pojazdu

    public int Kilometrage { get; set; }

    [JsonProperty("engine_parameters")]
    public EngineParameters EngineParameters { get; set; }

    public int Doors { get; set; }

    public bool Ac { get; set; } // Air Conditioner

    [JsonProperty("max_capacity")]
    public int SeatsNo { get; set; } // total number of seats (with driver seat included)

    public int Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"

    public List<string> Addons { get; set; } = new();

    public Pricing Pricing { get; set; } = new();

    public override string ToString()
    {
        return $"id:{Id} {Make} {Model} {Year} {Color} {Transmission} {EngineParameters.Type} {LicencePlateNumber} {GetAddonsToString()}";
    }

    public string GetDetails()
    {
        return $"#{Id}: Ma:{Make} Mo:{Model} Y:{Year} {Color} Ac:{Ac} {Transmission} {EngineParameters.Type} Seats:{SeatsNo}" +
            $"{VIN} Plates:{LicencePlateNumber}";
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
