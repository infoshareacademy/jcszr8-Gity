using CarRental.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic
{
    public class SearchViewModelDto
    {
        public string ModelAndMake { get; set; }
        public Dictionary<string, bool> Makes { get; set; }
        public Dictionary<string, bool> Models { get; set; }

        public int ProductionYearFrom { get; set; }
        public int ProductionYearTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Dictionary<string, bool> PremadeDic()
        {
            Dictionary<string, bool> make = new Dictionary<string, bool>();
            foreach (var maker in CarRentalData.Cars) 
            {
                make.Add(maker.ToString(),false);
            }
            return make;
        }
    }
}
