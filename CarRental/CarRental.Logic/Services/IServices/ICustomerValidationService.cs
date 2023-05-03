using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface ICustomerValidationService
{
    public bool IsAllValid(CustomerViewModel customer);
}
