using CarRental.Logic.Models;
using FluentValidation;

namespace CarRental.Logic.Validators;
public class CarViewModelValidator : AbstractValidator<CarViewModel>
{
    public CarViewModelValidator()
    {
        RuleFor(c => c.Make).NotEmpty().WithMessage("Make is required");
        RuleFor(c => c.CarModelProp).NotEmpty().WithMessage("Model is required");
        RuleFor(c => c.LicencePlateNumber).NotEmpty().WithMessage("Licence plate number is required");
        RuleFor(c => c.Year).NotEmpty().WithMessage("Year is required");
    }
}
