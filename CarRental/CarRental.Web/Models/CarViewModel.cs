using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models;

public class CarViewModel
{
    public int Id { get; set; }

    [Display(Name = "Model of the car")]
    [Required]
    public string CarModel { get; set; }

    [Display(Name = "Make of the car")]
    [Required]
    public string Make { get; set; }

    [Display(Name = "Year of production")]
    [Required]
    public int Year { get; set; }

    [Display(Name = "Number of licence plate")]
    [Required]
    public string LicencePlateNumber { get; set; }

    [Display(Name = "Make of the car")] 
    public string? Color { get; set; }

    [Display(Name = "Gearbox type")]
    public string? Transmission { get; set; }

    [Display(Name = "Car kilometrage")]
    public int? Kilometrage { get; set; }

    [Display(Name = "Power in kilowatts")]
    public float? PowerInKiloWats { get; set; }
    
    [Display(Name = "Engiene type")]
    public string? EngineType { get; set; }

    public string? Displacement { get; set; }

    public int? Doors { get; set; }
    [Display(Name = "Number of seats")]
    public int? SeatsNo { get; set; }

    public int? Airbags { get; set; }
    [Display(Name = "Fuel Consumption")]
    public string? FuelConsumption { get; set; }

    public List<string> Addons { get; set; } = new();

    public decimal? Price { get; set; }
}