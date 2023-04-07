using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface IRentalService
{
    List<RentalDto> GetAll();
    RentalDto Get(int id);
    void Create(RentalDto rental);
    void Update(RentalDto rental);
    void Delete(int id);

    List<int> GetAvailableCarIds(DateTime startDate, DateTime endDate);

    decimal GetRentalTotalPrice(decimal pricePerDay, DateTime rentStart, DateTime rentEnd);
}
