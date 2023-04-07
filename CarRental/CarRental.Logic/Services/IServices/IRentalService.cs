using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface IRentalService
{
    List<RentalModel> GetAll();
    RentalModel Get(int id);
    void Create(RentalModel rental);
    void Update(RentalModel rental);
    void Delete(int id);

    List<int> GetAvailableCarIds(DateTime startDate, DateTime endDate);

    decimal GetRentalTotalPrice(int carId, DateTime rentStart, DateTime rentEnd);
}
