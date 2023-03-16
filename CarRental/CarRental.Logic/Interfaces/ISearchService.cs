using CarRental.DAL.Models;

namespace CarRental.Logic.Interfaces;

public interface ISearchService
{
    List<Car> SearchList(SearchViewModelDto search);
}
