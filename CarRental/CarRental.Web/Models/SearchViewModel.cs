using CarRental.DAL.Models;
using CarRental.Logic;

namespace CarRental.Web.Models
{
    public class SearchViewModel
    {
        public SearchlDto SearchViewModelDto { get; set; } =  new SearchlDto();
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}