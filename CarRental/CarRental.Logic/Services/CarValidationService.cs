using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;
public class CarValidationService : ICarValidationService
{
    private readonly IValidator<CarViewModel> _validator;
    private readonly ILogger<CustomerValidationService> _logger;
    public CarValidationService(IValidator<CarViewModel> validator, ILogger<CustomerValidationService> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public bool IsValidForCreate(CarViewModel car)
    {
        var validationResult = _validator.Validate(car, options =>
        {
            options.IncludeRuleSets("CarCreate");
        });
        LogErrors(validationResult);
        return validationResult.IsValid;
    }

    public bool IsAllValid(CarViewModel car)
    {
        var validationResult = _validator.Validate(car, options =>
        {
            options.IncludeAllRuleSets();
        });
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
