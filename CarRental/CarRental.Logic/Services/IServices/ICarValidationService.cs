using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface ICarValidationService
{
    bool IsValidForCreate(CarViewModel car);
    bool IsAllValid(CarViewModel car);
}
