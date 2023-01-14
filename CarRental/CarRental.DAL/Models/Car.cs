using Newtonsoft.Json;
using System.Text;

namespace CarRental.DAL.Models;
public sealed class Car : Vehicle
{
    [JsonProperty("doors")]
    public int Doors { get; set; }

    [JsonProperty("ac")]
    public bool Ac { get; set; } // Air Conditioner

    [JsonProperty("max_capacity")]
    public int SeatsNo { get; set; } // total number of seats (with driver seat included)

    [JsonProperty("airbags")]
    public int Airbags { get; set; }

    [JsonProperty("fuel_consumption")]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"

    [JsonProperty("addons")]
    public List<string> Addons { get; set; } = new();

    [JsonProperty("pricing")]
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
            sb.AppendJoin(';',item.ToString());
            sb.Append('\u002C');
        }
        
        return sb.ToString();
    }
}
