using CarRental.DAL;

namespace CarRental.Logic.Models;

public class SearchFieldsModel
{
    public string ModelAndMake { get; set; }
    public Dictionary<string, bool> Makes { get; set; }
    public string Model { get; set; }
    public int ProductionYearFrom { get; set; }
    public int ProductionYearTo { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    public SearchFieldsModel()
    {
        //Makes = PrepareDictionary(); // TODO uncomment when PrepareDictionary() is implemented
    }

    public Dictionary<string, bool> PrepareDictionary()
    {
        Dictionary<string, bool> make = new Dictionary<string, bool>();

        throw new NotImplementedException();
        // var group = CarRentalData.Cars.Select(car => car.Make).Distinct();  // TODO because CarRentalData class was removed, with code moved to Seed class

        //foreach (var carMake in group)
        //{
        //    make.Add(carMake, false);
        //}
        //return make;
    }
}
