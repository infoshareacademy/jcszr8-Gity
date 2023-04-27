using CarRental.DAL.Context;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;

public class SearchFieldsModel
{
    public string ModelAndMake { get; set; }
    public Dictionary<string, bool> Makes { get; set; }
    public string Model { get; set; }
    public int ProductionYearFrom { get; set; }
    public int ProductionYearTo { get; set; }
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    public SearchFieldsModel()
    {
        Makes = PrepareDictionary();
    }

    public Dictionary<string, bool> PrepareDictionary()
    {
        Dictionary<string, bool> make = new Dictionary<string, bool>();
        var group = Seed.Cars.Select(car => car.Make).Distinct();

        foreach (var carMake in group)
        {
            make.Add(carMake, false);
        }
        return make;
    }
}
