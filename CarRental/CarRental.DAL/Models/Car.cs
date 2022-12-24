using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Models
{
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

        [JsonProperty("fuel_consumption_city")]
        public float FuelConsumptionCity { get; set; }

        [JsonProperty("fuel_consumption_highway")]
        public float FuelConsumptionHighway { get; set; }

        [JsonProperty("segment")]
        public string? Segment { get; set; }

        [JsonProperty("addons")]
        public List<string> Addons { get; set; } = new();

        [JsonProperty("pricing")]
        public Dictionary<string, string> Pricing = new();

        public override string ToString()
        {
            return $"id:{Id} {Make} {Model} {Year} {Color} {Transmission} {EngineParameters.Type} {LicencePlateNumber}";
        }

        public string GetDetails()
        {
            return $"#{Id}: Ma:{Make} Mo:{Model} Y:{Year} {Color} Ac:{Ac} {Transmission} {EngineParameters.Type} Seats:{SeatsNo}" +
                $"{VIN} Plates:{LicencePlateNumber}";
        }
    }
}
