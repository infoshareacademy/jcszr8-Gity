using CarRental.Logic;
namespace CarRental.Web.Models;

public class SearchViewModel
{
    public SearchViewModelDto SearchViewModelDto { get; set; }

    public IEnumerable<CarListModel> Cars { get; set; } = new List<CarListModel>();
}
