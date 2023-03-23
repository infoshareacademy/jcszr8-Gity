using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Web.Models
{
    public class SearchViewModel
    {
        public SearchBLL SearchDto { get; set; } = new SearchBLL();
        public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}
