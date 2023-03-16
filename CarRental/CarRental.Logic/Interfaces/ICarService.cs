using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICarService
{
    List<Car> GetAll();
    Car GetById(int carId);
    List<Car> CarByName(string make);
    List<Car> CarByModel(string name);
    List<Car> CarByYear(string read);
    List<Car> CarByAddons(string addon);
    void Create(Car car);

    void Update(Car car);

    void Delete(int  carId);
}
