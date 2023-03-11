using CarRental.Logic;

namespace CarRental.Web.Models
{
    public class SearchViewModel
    {
        public SearchViewModelDto SearchViewModelDto { get; set; }
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
        
    }
}
