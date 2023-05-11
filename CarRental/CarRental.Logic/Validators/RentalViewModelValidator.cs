using CarRental.Logic.Models;
using FluentValidation;

namespace CarRental.Logic.Validators;
public class RentalViewModelValidator : AbstractValidator<RentalViewModel>
{
    public RentalViewModelValidator()
    {
        RuleSet("Create", () =>
        {
            RuleFor(r => r.BeginDate)
             .Must(ValidationRules.IsValid)
             .WithMessage("Begin date should be in the future");
        });

        RuleFor(r => r.BeginDate)
            .NotEmpty()
            .WithMessage("Begin date is required");
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
        // below line can be potentially problematic, ex. add 1 second can be too small addtion
        // (checked in debug mode)
        return beginDate.AddSeconds(300) > DateTime.Now;
    }
}
