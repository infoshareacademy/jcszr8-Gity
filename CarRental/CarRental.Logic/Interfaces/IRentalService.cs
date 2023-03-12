using CarRental.DAL.Models;

namespace CarRental.Logic.Interfaces;

public interface IRentalService
{
    IEnumerable<int> GetAvailableCarIds(DateTime start, DateTime end);
    IEnumerable<Car> ListOfAvailableCarForRent(List<int> carIds);
    IEnumerable<int> GetNotRented();
    IEnumerable<int> GetAvailableInGivenTime(DateTime start, DateTime end);
}
