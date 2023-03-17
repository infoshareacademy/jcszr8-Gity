using CarRental.DAL.Models;
using CarRental.Logic;

namespace CarRental.Web.Models
{
    public class SearchViewModel
    {
        public SearchDto SearchDto { get; set; } =  new SearchDto();
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}