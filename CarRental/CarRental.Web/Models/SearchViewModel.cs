using CarRental.Logic.Models;

namespace CarRental.Web.Models;

public class SearchViewModel
{
    public SearchFieldsModel SearchDto { get; set; } = new SearchFieldsModel();
    public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();
}
