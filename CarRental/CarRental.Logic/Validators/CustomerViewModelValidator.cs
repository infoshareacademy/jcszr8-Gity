using CarRental.Logic.Models;
using FluentValidation;

namespace CarRental.Logic.Validators;
public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
{
    public CustomerViewModelValidator()
    {
        RuleSet("Names", () =>
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(30)
                .WithMessage($"Maximum length for first name is {0}");
        });
        //RuleFor(c => c.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(c => c.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(c => c.EmailAddress).NotEmpty().WithMessage("Email is required");
        RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
    }   
}
