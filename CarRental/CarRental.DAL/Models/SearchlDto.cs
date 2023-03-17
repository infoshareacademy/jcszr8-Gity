using CarRental.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic
{
    public class SearchlDto
    {
        public string ModelAndMake { get; set; }
        public Dictionary<string, bool> Makes { get; set; }
        public string Model { get; set; }

        public int ProductionYearFrom { get; set; }
        public int ProductionYearTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SearchlDto() 
        {
            Makes = PremadeDictionary();
        }

        public Dictionary<string, bool> PremadeDictionary()
        {
            Dictionary<string, bool> make = new Dictionary<string, bool>();
            foreach (var carMake in CarRentalData.Cars.Select(car => car.Make).Distinct())
            {
                make.Add(carMake, false);
            }
            return make;
        }
    }
}
