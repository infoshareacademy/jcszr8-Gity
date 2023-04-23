using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Models;
public class CarCreateViewModel : CarViewModel
{
    public List<string> CheckedAddons { get; set; } = new();

    //List<string> availableAddons = new() { "Ac", "ABS", "towbar", "roof rack" };
}
