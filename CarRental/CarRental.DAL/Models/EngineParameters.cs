using CarRental.DAL.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Models
{
    public struct EngineParameters
    {
        [JsonProperty("power_kw")]
        public float PowerInKiloWats { get; set; }
        [JsonProperty("power_km")]
        public float PowerInKM { get; set; } // Horse Power - konie mechaniczne; 1KM=735,49875W=0,9863 HP; 1kW = 1.36KM

        [JsonProperty("fuel_type")]
        public EngineType Type { get; set; }

        [JsonProperty("displacement")]
        public string Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.

        [JsonProperty("torque")]
        public string Torque; // in Nm; moment obrotowy; np. 125 Nm przy 6500 obr./min.
    }
}
