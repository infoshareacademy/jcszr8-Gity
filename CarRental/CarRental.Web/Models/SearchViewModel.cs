using CarRental.Logic.Models;

namespace CarRental.Web.Models;

public class SearchViewModel
{
    public SearchCarModel SearchDto { get; set; } = new SearchCarModel();
    public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();
}
