using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface IRentalService
{
    List<RentalViewModel> GetAll();
    RentalViewModel Get(int id);
    void Create(RentalViewModel rental);
    void Update(RentalViewModel rental);
    void Delete(int id);

    List<int> GetAvailableCarIds(DateTime startDate, DateTime endDate);

    decimal GetRentalTotalPrice(decimal pricePerDay, DateTime rentStart, DateTime rentEnd);

    IEnumerable<RentalViewModel> GetRentalsByCarId(int carId);
}
