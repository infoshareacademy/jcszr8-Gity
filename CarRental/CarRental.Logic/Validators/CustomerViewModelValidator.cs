using CarRental.Common;
using CarRental.Logic.Models;
using FluentValidation;

namespace CarRental.Logic.Validators;
public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
{
    public CustomerViewModelValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("First name is required")
            .MaximumLength(AppConfig.FirstNameMaxLength)
            .WithMessage($"Maximum length for first name is {AppConfig.FirstNameMaxLength}");
        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("Last name is required");
        RuleFor(c => c.EmailAddress)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid")
            .MaximumLength(AppConfig.EmailAddressMaxLength)
            .WithMessage($"Maximum length for email is {AppConfig.EmailAddressMaxLength}");
        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
            .MinimumLength(AppConfig.PhoneNumberMinLength)
            .WithMessage($"Minimum length for phone number is {AppConfig.PhoneNumberMinLength}")
            .MaximumLength(AppConfig.PhoneNumberMaxLength)
            .WithMessage($"Maximum length for phone number is {AppConfig.PhoneNumberMaxLength}");
        RuleFor(c => c.Pesel)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Pesel is required")
            .Length(AppConfig.PeselLength)
            .WithMessage($"Pesel must have {AppConfig.PeselLength} characters")
            .Matches(@"^\d{11}$")
            .WithMessage("Pesel must contain only digits");
    }
}
