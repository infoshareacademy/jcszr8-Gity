using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ISearchService
{
    List<CarModel> SearchList(SearchCarModel search);
    List<CarModel> FilterList(SearchCarModel searchDto);
}
