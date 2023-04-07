using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ISearchService
{
    List<CarDto> SearchList(SearchFieldsModel search);
    List<CarDto> FilterList(SearchFieldsModel searchDto);
}
