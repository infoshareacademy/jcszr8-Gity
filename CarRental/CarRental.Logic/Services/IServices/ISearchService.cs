using CarRental.DAL.Models;

namespace CarRental.Logic.Services.IServices;

public interface ISearchService
{
    List<CarModel> SearchList(SearchBLL search);
    List<CarModel> FilterList(SearchBLL searchDto);
}
