using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICarService
{
    List<Car> GetAll();
    Car GetById(int carId);
}
