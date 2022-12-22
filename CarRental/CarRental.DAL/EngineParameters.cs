using CarRental.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public struct EngineParameters
    {
        public float PowerInHP { get; set; } // Horse Power - konie mechaniczne
        public float PowerInWats { get; set; }
        public EngineType Type { get; set; }
        public float Displacement { get; set; } // in cubic centimeters

        public string Torque; // in Nm; moment obrotowy; np. 125 Nm przy 6500 obr./min.
    }
}
