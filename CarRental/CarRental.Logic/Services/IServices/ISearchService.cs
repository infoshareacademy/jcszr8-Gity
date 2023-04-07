using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ISearchService
{
    List<CarModel> SearchList(SearchFieldsModel search);
    List<CarModel> FilterList(SearchFieldsModel searchDto);
}
