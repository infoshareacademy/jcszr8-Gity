using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICarService
{
    IEnumerable<CarDto> GetAll();

    CarDto? Get(int id);

    // TODO czy te 3 poniższe nie powinny pójść do serwisu wyszukiwania
    IEnumerable<CarDto> GetByName(string make);

    List<CarDto> GetByYear(string read);

    void Create(CarDto car);

    void Update(CarDto car);

    void Delete(int id);
}
