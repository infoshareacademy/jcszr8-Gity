using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IRentalValidationService
{
    bool IsAllValid(RentalViewModel rental);
}
