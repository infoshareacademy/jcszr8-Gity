using CarRental.DAL.Models;

namespace CarRental.Logic.Services.IServices;

public interface ISearchService
{
    List<Car> SearchList(SearchDto search);
    List<Car> FilterList(SearchDto searchDto);
}
