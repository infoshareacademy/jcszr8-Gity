using CarRental.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Models
{
    public struct EngineParameters
    {
        public float PowerInKiloWats { get; set; }
        public float PowerInKM { get; set; } // Horse Power - konie mechaniczne; 1KM=735,49875W=0,9863 HP; 1kW = 1.36KM
        public EngineType Type { get; set; }
        public float Displacement { get; set; } // in cubic centimeters

        public string Torque; // in Nm; moment obrotowy; np. 125 Nm przy 6500 obr./min.
    }
}
