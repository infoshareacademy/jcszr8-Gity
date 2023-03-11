using CarRental.DAL.Models;

namespace CarRental.Logic.Interfaces;

public interface IRentalService
{
    List<int> GetAvailableCarIds(DateTime start, DateTime end);
    List<Car> ListOfAvailableCarForRent(List<int> carIds);
    List<int> GetNotRented();
    List<int> GetAvailableInGivenTime(DateTime start, DateTime end);
}
