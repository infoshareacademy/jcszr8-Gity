﻿namespace CarRental.DAL.Entities;

public class SearchBLL
{
    public string ModelAndMake { get; set; }
    public Dictionary<string, bool> Makes { get; set; }
    public string Model { get; set; }

    public int ProductionYearFrom { get; set; }
    public int ProductionYearTo { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    public SearchBLL()
    {
        Makes = PremadeDictionary();
    }

    public Dictionary<string, bool> PremadeDictionary()
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
