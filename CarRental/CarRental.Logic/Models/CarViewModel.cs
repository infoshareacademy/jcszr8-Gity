using CarRental.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;
public class CarViewModel
{
    #region Properties/Fields

    public int Id { get; set; }

    [Display(Name = "Car Model")]
    [Required]
    public string? CarModelProp { get; set; }


    [Required]
    public string? Make { get; set; }

    [Display(Name = "Year Of Production")]
    [Required]
    public int Year { get; set; }

    [Display(Name = "Licence Plate")]
    [Required]
    public string? LicencePlateNumber { get; set; }
    public string? Color { get; set; }
    [Display(Name = "Transmission Type")]
    public TransmissionType? Transmission { get; set; }
    public int? Kilometrage { get; set; }
    [Display(Name = "Power In Kilowatts")]
    public float? PowerInKiloWats { get; set; }
    
    [Display(Name = "Engine Type")]
    public EngineType? EngineType { get; set; }
    public string? Displacement { get; set; } // ex. 1.8, 1.5 T-GDI, etc.
    public int? Doors { get; set; }
    [Display(Name = "Number Of Seats")]
    public int? SeatsNo { get; set; } // total number of seats (with driver seat included)
    public int? Airbags { get; set; }
    [Display(Name = "Fuel Consumption")]
    public string? FuelConsumption { get; set; } // in l/100km format city/highway, ex. "6.5/4.5"
    public List<string> Addons { get; set; } = new();
    public decimal? Price { get; set; }

    #endregion
}
