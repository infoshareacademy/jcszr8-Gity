using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Make { get; set; }
        public int Year { get; set; } // production year
        public string? Color { get; set; }
        public string? Transmission { get; set; }
        public int MaximumSpeed { get; set; } // in km/h

        [JsonProperty("fuel_type")]
        public string? EngineType { get; set; }
        public string? VIN { get; set; } // Vehicle Identification Number
        public string? LicencePlateNumber { get; set; } // numer rejestracyjny pojazdu

        public Dictionary<string, string> Images = new Dictionary<string, string>(); // dictionary for paths to car images


        public override string ToString()
        {
            return $"{this.GetType()}: {Model} {Make} {LicencePlateNumber} (id:{Id})";
        }
    }
}
