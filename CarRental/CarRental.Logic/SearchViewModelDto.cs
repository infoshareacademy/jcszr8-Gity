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
        public int ProductionYearFrom { get; set; }
        public int ProductionYearTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
