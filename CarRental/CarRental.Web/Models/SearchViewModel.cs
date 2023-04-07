using CarRental.Logic.Models;

namespace CarRental.Web.Models;

public class SearchViewModel
{
    public SearchFieldsModel SearchDto { get; set; } = new SearchFieldsModel();
    public IEnumerable<CarDto> Cars { get; set; } = new List<CarDto>();
}
