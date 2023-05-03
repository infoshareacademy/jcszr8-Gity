using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;

namespace CarRental.Logic.Services;
class RentalValidationService : IRentalValidationService
{
    private readonly IValidator<RentalViewModel> _validator;
    public RentalValidationService(IValidator<RentalViewModel> validator)
    {
        _validator = validator;
    }
    public bool IsAllValid(RentalViewModel rental)
    {
        var validationResult = _validator.Validate(rental, options =>
        {
            options.IncludeAllRuleSets();
        });
        return validationResult.IsValid;
    }
}
