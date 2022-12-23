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
        public int Doors { get; set; }
        public bool Ac { get; set; } // Air Conditioner

        [JsonProperty("max_capacity")]
        public int SeatsNo { get; set; } // total number of seats (with driver seat included)
        public List<string> Addons { get; set; } = new();

        public Dictionary<string, string> Pricing = new();

        public override string ToString()
        {
            return $"{GetType()}: {Model} {Make} {Year} {Color} {Transmission} {EngineType} {LicencePlateNumber}";
        }

        public void PrintDetails()
        {
            Console.WriteLine($"#{Id}: M: {Model} M: {Make} Y:{Year} {Color} Ac:{Ac} {Transmission} {EngineType} Seats: {SeatsNo}" +
                $"{VIN} Plates:{LicencePlateNumber}");
        }
    }
}
