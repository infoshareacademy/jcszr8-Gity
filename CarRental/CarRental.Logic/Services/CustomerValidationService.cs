using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;
public class CustomerValidationService : ICustomerValidationService
{
    private readonly IValidator<CustomerViewModel> _validator;
    private readonly ILogger<CustomerValidationService> _logger;
    public CustomerValidationService(IValidator<CustomerViewModel> validator,
        ILogger<CustomerValidationService> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public bool IsAllValid(CustomerViewModel customer)
    {
        var validationResult = _validator.Validate(customer);
        LogErrors(validationResult);
        return validationResult.IsValid;
    }

    private void LogErrors(ValidationResult validationResult)
    {
        foreach (var failure in validationResult.Errors)
        {
            _logger.LogInformation("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
        }
    }
}
