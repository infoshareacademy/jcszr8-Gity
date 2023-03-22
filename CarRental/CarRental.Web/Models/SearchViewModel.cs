using CarRental.DAL.Models;
using CarRental.Logic;

namespace CarRental.Web.Models
{
    public class SearchViewModel
    {
        public SearchBLL SearchDto { get; set; } =  new SearchBLL();
        public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}