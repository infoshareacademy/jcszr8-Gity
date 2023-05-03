using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;
public class RentalValidationService : IRentalValidationService
{
    private readonly IValidator<RentalViewModel> _validator;
    private readonly ILogger<CustomerValidationService> _logger;
    public RentalValidationService(IValidator<RentalViewModel> validator, ILogger<CustomerValidationService> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public bool IsAllValid(RentalViewModel rental)
    {
        var validationResult = _validator.Validate(rental, options =>
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
