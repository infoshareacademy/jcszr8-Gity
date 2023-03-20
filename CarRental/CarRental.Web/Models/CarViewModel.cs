using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models;

public class CarViewModel
{
    public int Id { get; set; }

    [Display(Name = "Model")]
    [Required]
    public string CarModel { get; set; }

    [Required]
    public string Make { get; set; }

    [Required]
    public int Year { get; set; }

    [Display(Name = "Licence Plate")]
    [Required]
    public string LicencePlateNumber { get; set; }

    public string? Color { get; set; }

    public string? Transmission { get; set; }

    public int? Kilometrage { get; set; }

    public float? PowerInKiloWats { get; set; }

    public string? EngineType { get; set; }

    public string? Displacement { get; set; }

    public int? Doors { get; set; }

    public int? SeatsNo { get; set; }

    public int? Airbags { get; set; }

    public string? FuelConsumption { get; set; }

    public List<string> Addons { get; set; } = new();

    public decimal? Price { get; set; }
}