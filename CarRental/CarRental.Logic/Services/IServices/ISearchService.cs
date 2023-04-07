using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ISearchService
{
    List<CarViewModel> SearchList(SearchFieldsModel search);
    List<CarViewModel> FilterList(SearchFieldsModel searchDto);
}
