using CarRental.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI
{
    internal record CarDto
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Make { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }
        public string? Transmission { get; set; }
        public string? VIN { get; set; }
        public string? LicencePlateNumber { get; set; }

        public Dictionary<string, string> Images = new Dictionary<string, string>();
        public int Kilometrage { get; set; }
        public EngineParameters EngineParameters { get; set; }
        public int Doors { get; set; }
        public bool Ac { get; set; }
        public int SeatsNo { get; set; }
        public int Airbags { get; set; }
        public float FuelConsumptionCity { get; set; }
        public float FuelConsumptionHighway { get; set; }
        public string? Segment { get; set; }
        public List<string> Addons { get; set; } = new();

        public Dictionary<string, string> Pricing = new();
    }
}
