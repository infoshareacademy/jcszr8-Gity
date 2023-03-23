using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICarService
{
    IEnumerable<CarModel> GetAll();

    CarModel? Get(int id);

    // TODO czy te 3 poniższe nie powinny pójść do serwisu wyszukiwania
    IEnumerable<CarModel> GetByName(string make);

    List<CarModel> GetByYear(string read);

    //List<CarModel> GetByAddons(string addon);

    void Create(CarModel car);

    void Update(CarModel car);

    void Delete(int id);
}
