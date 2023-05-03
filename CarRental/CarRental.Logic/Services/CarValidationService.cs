using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;

namespace CarRental.Logic.Services;
class CarValidationService : ICarValidationService
{
    private readonly IValidator<CarViewModel> _validator;
    public CarValidationService(IValidator<CarViewModel> validator)
    {
        _validator = validator;
    }

    public bool IsValidForCreate(CarViewModel car)
    {
        var validationResult = _validator.Validate(car, options =>
        {
            options.IncludeRuleSets("CarCreate");
        });
        return validationResult.IsValid;
    }

    public bool IsAllValid(CarViewModel car)
    {
        var validationResult = _validator.Validate(car, options =>
        {
            options.IncludeAllRuleSets();
        });
        return validationResult.IsValid;
    }
}
