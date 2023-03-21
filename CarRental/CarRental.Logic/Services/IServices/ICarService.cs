using CarRental.DAL.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICarService
{
    IEnumerable<Car> GetAll();
    Car? GetById(int id);

    // TODO czy te 3 poniższe nie powinny pójść do serwisu wyszukiwania
    IEnumerable<Car> GetByName(string make);
    List<Car> GetByYear(string read);
    List<Car> GetByAddons(string addon);
    void Create(Car car);

    void Update(Car car);

    void Delete(int id);
}
