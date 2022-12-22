using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public sealed class Motorcycle : Vehicle
    {
        public int WeightInKg;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
