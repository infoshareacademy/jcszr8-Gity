using CarRental.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models;

public class CarViewModel
{
    public int Id { get; set; }

    [Display(Name = "Model")]
    public string? CarModel { get; set; }

    public string? Make { get; set; }

    public int? Year { get; set; }

    [Display(Name = "Licence Plate")]
    public string? LicencePlateNumber { get; set; }
    public CarViewModel FillModel(Car baseModel)
    {
        this.Id = baseModel.Id;
        this.CarModel = baseModel.CarModel;
        this.Make = baseModel.Make;
        return this;
    }
}