using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICarService
{
    IEnumerable<CarViewModel> GetAll();

    CarViewModel? Get(int id);

    // TODO czy te 3 poniższe nie powinny pójść do serwisu wyszukiwania
    IEnumerable<CarViewModel> GetByName(string make);

    List<CarViewModel> GetByYear(string read);
    List<CarViewModel> FindCars(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel);

    void Create(CarViewModel car);

    void Update(CarViewModel car);

    void Delete(int id);
}
