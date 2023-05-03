using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;

namespace CarRental.Logic.Services;
public class CustomerValidationService : ICustomerValidationService
{
    private readonly IValidator<CustomerViewModel> _validator;
    public CustomerValidationService(IValidator<CustomerViewModel> validator)
    {
        _validator = validator;
    }

    public bool IsAllValid(CustomerViewModel customer)
    {
        var validationResult = _validator.Validate(customer);
        return validationResult.IsValid;
    }
}
