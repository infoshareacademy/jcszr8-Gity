using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICarService
{
    List<Car> GetAll();
    Car GetById(int carId);
    List<Car> CarByName(string make);
    List<Car> CarByYear(string read);
    List<Car> CarByAddons(string addon);
    List<Car> SearchList(string text);
    void Create(Car car);
}
