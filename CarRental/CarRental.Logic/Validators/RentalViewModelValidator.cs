using CarRental.Logic.Models;
using FluentValidation;

namespace CarRental.Logic.Validators;
public class RentalViewModelValidator : AbstractValidator<RentalViewModel>
{
    public RentalViewModelValidator()
    {
        RuleFor(r => r.BeginDate)
            .NotEmpty()
            .WithMessage("Begin date is required")
            .Must(ValidationRules.IsValid);
        RuleFor(r => r.EndDate)
            .NotEmpty()
            .WithMessage("End date is required")
            .GreaterThanOrEqualTo(r => r.BeginDate.AddDays(1))
            .WithMessage("End date must be at least one day greater than begin date");
    }
}

public static class ValidationRules
{
    public static bool IsValid(DateTime beginDate)
    {
        return beginDate > DateTime.Now;
    }
}
