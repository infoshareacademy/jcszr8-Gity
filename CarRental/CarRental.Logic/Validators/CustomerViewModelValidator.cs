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
            .WithMessage("Pesel must contain only digits")
            .Must(PeselValidator.ValidatePesel);
    }
}

public static class PeselValidator
{
    private static readonly int[] multipliers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

    public static bool ValidatePesel(string pesel)
    {
        if (AppConfig.UsePeselChecksumValidation == false)
        {
            return true;
        }

        bool result = false;
        try
        {
            if (pesel.Length == 11)
            {
                result = CountSum(pesel).Equals(pesel[10].ToString());
            }
        }
        catch (Exception)
        {
            result = false;
        }
        return result;
    }

    private static string CountSum(string pesel)
    {
        int sum = 0;
        for (int i = 0; i < multipliers.Length; i++)
        {
            sum += multipliers[i] * int.Parse(pesel[i].ToString());
        }

        int remainder = sum % 10;
        return remainder == 0 ? remainder.ToString() : (10 - remainder).ToString();
    }
}
