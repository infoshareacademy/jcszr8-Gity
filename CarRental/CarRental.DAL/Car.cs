using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class Car
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; } // production year
        public string Color { get; set; }
        public bool Ac { get; set; } // Air Conditioner
        public string Transmission { get; set; }
        [JsonProperty("fuel_type")]
        public string FuelType { get; set; }
        [JsonProperty("max_capacity")]
        public int MaxCapacity { get; set; } // number of seats
        public List<string> Addons { get; set; }

        public string VIN { get; set; } //Vehicle Identification Number

        public string PlatesNumber { get; set; } // numer rejestracyjny pojazdu

        public Dictionary<string, string> Images = new Dictionary<string, string>(); // dictionary for paths to car images

        public void PrintCarDetails()
        {
            Console.WriteLine($"\n\nCarDetails: \nModel: {Model} \nMake: {Make} " +
                $"\nYear: {Year} \nColor: {Color} \nAc: {Ac} " +
                $"\nTransmission: {Transmission} \nFuelType: {FuelType} \nMaxCapacity: {MaxCapacity}" +
                $"\nVIN: {VIN} \nPlates Number: {PlatesNumber}");
        }
    }
}
