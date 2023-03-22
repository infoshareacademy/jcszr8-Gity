using CarRental.DAL.Models;

namespace CarRental.Logic.Services.IServices;

public interface IRentalService
{
    List<RentalModel> GetAll();

    RentalModel GetById(int id);

    void Create(RentalModel rental);

    void Update(RentalModel rental);

    void Delete(int id);

    IEnumerable<int> GetAvailableCarIds(DateTime start, DateTime end);

    IEnumerable<CarModel> ListOfAvailableCarForRent(List<int> carIds);

    IEnumerable<int> GetNotRented();

    IEnumerable<int> GetAvailableInGivenTime(DateTime start, DateTime end);
}
