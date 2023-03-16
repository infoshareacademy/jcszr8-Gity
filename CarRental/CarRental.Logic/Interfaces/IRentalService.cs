using CarRental.DAL.Models;

namespace CarRental.Logic.Interfaces;

public interface IRentalService
{
    List<Rental> GetAll();

    Rental GetById(int id);

    void Create(Rental rental);

    void Update(Rental rental);

    void Delete(int id);

    IEnumerable<int> GetAvailableCarIds(DateTime start, DateTime end);

    IEnumerable<Car> ListOfAvailableCarForRent(List<int> carIds);

    IEnumerable<int> GetNotRented();

    IEnumerable<int> GetAvailableInGivenTime(DateTime start, DateTime end);
}
