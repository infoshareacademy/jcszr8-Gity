using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface ICarRentabilityService
{
    IEnumerable<int> GetIdsForCarsAvailableInGivenTerm(DateTime startDate, DateTime endDate);
    IEnumerable<CarDto> GetCarsAvailableInGivenTerm(DateTime termStart, DateTime termEnd);

    IEnumerable<RentalDto> GetRentalsNotCollidingWithTerm(DateTime termStart, DateTime termEnd);
    IEnumerable<RentalDto> GetRentalsCollidingWithTerm(DateTime startDate, DateTime endDate);

    bool IsCarAvailableForRentInGivenTerm(int carId, DateTime startDate, DateTime endDate);
    bool IsCarBookedForRentInGivenTerm(int carId, DateTime startDate, DateTime endDate);
}
