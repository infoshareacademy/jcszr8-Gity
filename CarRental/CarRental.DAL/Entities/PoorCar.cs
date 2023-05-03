using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Entities;
public class PoorCar
{
    public int Id { get; set; }

    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.
}
