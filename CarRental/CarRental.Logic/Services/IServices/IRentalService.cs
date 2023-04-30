using CarRental.Common;
using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface IRentalService
{
    List<RentalViewModel> GetAll();
    RentalViewModel Get(int id);
    void Create(RentalViewModel rental);
    void Update(RentalViewModel rental);
    void Delete(int id);
    IEnumerable<RentalViewModel> GetByCarId(int carId);
    IEnumerable<CarViewModel> GetCarsAvailableInTerm(Term wantedTerm);
    bool IsCarBookedInTerm(int carId, Term wantedTerm);
    decimal GetRentalTotalPrice(decimal pricePerDay, DateTime rentStart, DateTime rentEnd);
}
