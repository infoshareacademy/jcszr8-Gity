using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICarService
{
    List<Car> GetAll();
    Car GetById(int carId);
    List<Car> CarByName(string make);
    List<Car> CarByYear(string read);
    List<Car> CarByAddons(string addon);
    //List<Car> CarByMaker(Dictionary<string, bool> makers);
    void Create(Car car);

    void Update(Car car);

    void Delete(int  carId);
}
