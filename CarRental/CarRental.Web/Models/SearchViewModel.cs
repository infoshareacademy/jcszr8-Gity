using CarRental.DAL.Models;
using CarRental.Logic;

namespace CarRental.Web.Models
{
    public class SearchViewModel
    {
        public SearchViewModelDto SearchViewModelDto { get; set; } =  new SearchViewModelDto();
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
        
    }
}