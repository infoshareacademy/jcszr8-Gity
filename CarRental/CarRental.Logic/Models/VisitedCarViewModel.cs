using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Models;
public class VisitedCarViewModel
{
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime DateWhenClicked { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicencePlate { get; set; }
}
