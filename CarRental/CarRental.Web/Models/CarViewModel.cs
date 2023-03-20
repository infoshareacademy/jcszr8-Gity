using CarRental.DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

    public CarViewModel FillModel(Car baseModel)
    {
        this.Id = baseModel.Id;
        this.CarModel = baseModel.CarModel;
        this.Make = baseModel.Make;
        this.Year = baseModel.Year;
        this.LicencePlateNumber = baseModel.LicencePlateNumber;
        this.Color = baseModel.Color;
        this.Transmission = baseModel.Transmission;
        this.Kilometrage = baseModel.Kilometrage;
        this.Airbags = baseModel.Airbags;
        this.SeatsNo = baseModel.SeatsNo;
        this.PowerInKiloWats = baseModel.PowerInKiloWats;
        this.Displacement = baseModel.Displacement;
        this.Doors = baseModel.Doors;
        this.EngineType = baseModel.EngineType;
        this.FuelConsumption = baseModel.FuelConsumption;
        this.Addons = baseModel.Addons;
        this.Price = baseModel.Price;

        return this;
    }

    public Car FillEntity()
    {
        var car = new Car
        {
            Id = this.Id,
            CarModel = this.CarModel,
            Make = this.Make,
            LicencePlateNumber = this.LicencePlateNumber,
            Year = this.Year,
            Color = this.Color,
            Transmission = this.Transmission,
            Kilometrage = this.Kilometrage,
            Airbags = this.Airbags,
            SeatsNo = this.SeatsNo,
            PowerInKiloWats = this.PowerInKiloWats,
            Displacement = this.Displacement,
            Doors = this.Doors,
            EngineType = this.EngineType,
            FuelConsumption = this.FuelConsumption,
            Price = this.Price,
            Addons = this.Addons,
        };

        return car;
    }
}