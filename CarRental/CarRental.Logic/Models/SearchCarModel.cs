using CarRental.DAL;

namespace CarRental.Logic.Models;

public class SearchCarModel
{
    public string ModelAndMake { get; set; }
    public Dictionary<string, bool> Makes { get; set; }
    public string Model { get; set; }
    public int ProductionYearFrom { get; set; }
    public int ProductionYearTo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public SearchCarModel()
    {
        Makes = PrepareDictionary();
    }

    public Dictionary<string, bool> PrepareDictionary()
    {
        Dictionary<string, bool> make = new Dictionary<string, bool>();

        var group = CarRentalData.Cars.Select(car => car.Make).Distinct();

        foreach (var carMake in group)
        {
            make.Add(carMake, false);
        }
        return make;
    }
}
