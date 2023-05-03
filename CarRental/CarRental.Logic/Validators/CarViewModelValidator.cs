using CarRental.Logic.Models;
using FluentValidation;
using static CarRental.Common.AppConfig;

namespace CarRental.Logic.Validators;
public class CarViewModelValidator : AbstractValidator<CarViewModel>
{
    public CarViewModelValidator()
    {
        RuleSet("CarCreate", () =>
        {
            RuleFor(c => c.Make)
                .NotEmpty()
                .WithMessage("Make is required")
                .MaximumLength(CarMakeMaxLength)
                .WithMessage($"Maximum length for make is {CarMakeMaxLength}");
            RuleFor(c => c.CarModelProp)
                .NotEmpty()
                .WithMessage("Model is required")
                .MaximumLength(CarMakeMaxLength)
                .WithMessage($"Maximum model length is {CarModelMaxLength}");
            RuleFor(c => c.LicencePlateNumber)
                .NotEmpty()
                .WithMessage("Licence plate number is required")
                .MinimumLength(CarLicencePlateNumberMinLength)
                .WithMessage($"Minimum licence plate number length is {CarLicencePlateNumberMinLength}")
                .MaximumLength(CarLicencePlateNumberMaxLength)
                .WithMessage($"Maximum licence plate number length is {CarLicencePlateNumberMaxLength}");
            RuleFor(c => c.Year)
                .NotEmpty()
                .WithMessage("Year is required")
                .GreaterThanOrEqualTo(CarYearMinValue)
                .WithMessage($"Minimum value for year is {CarYearMinValue}")
                .LessThanOrEqualTo(CarYearMaxValue)
                .WithMessage($"Maximum value for year is {CarYearMaxValue}");
        });

        RuleFor(c => c.Color)
            .IsInEnum()
            .WithMessage("Color should be selcted from list");
        RuleFor(c => c.Transmission)
            .IsInEnum()
            .WithMessage("Transmission should be selected from list");
        RuleFor(c => c.Kilometrage)
            .GreaterThanOrEqualTo(CarKilometrageMinValue)
            .WithMessage($"Minimum value for kilomegrage is {CarKilometrageMinValue}")
            .LessThanOrEqualTo(CarKilometrageMaxValue)
            .WithMessage($"Maximum value for kilometrage is {CarKilometrageMaxValue}");
        RuleFor(c => c.PowerInKiloWatts)
            .GreaterThanOrEqualTo(CarPowerInKiloWattsMinValue)
            .WithMessage($"Minimum value for power is {CarPowerInKiloWattsMinValue} kW") // TODO if change from kW to W
            .LessThanOrEqualTo(CarPowerInKiloWattsMaxValue)
            .WithMessage($"Maximum value for power is {CarPowerInKiloWattsMaxValue} kW"); // TODO if change from kW to W
        RuleFor(c => c.EngineType)
            .IsInEnum()
            .WithMessage("Engine type should be selected from list");
        RuleFor(c => c.Displacement)
            .MaximumLength(CarDisplacementMaxLength)
            .WithMessage($"Maximum length for engine displacement is {CarDisplacementMaxLength}");
        RuleFor(c => c.Doors)
            .GreaterThanOrEqualTo(CarDoorsNoMinValue)
            .WithMessage($"Minimum value for number of doors is {CarDoorsNoMinValue}")
            .LessThan(CarDoorsNoMaxValue)
            .WithMessage($"Maximum value for number of doors is {CarDoorsNoMaxValue}");
        RuleFor(c => c.SeatsNo)
            .GreaterThanOrEqualTo(CarSeatsNoMinValue)
            .WithMessage($"Minimum value for number of seats is {CarSeatsNoMinValue}")
            .LessThan(CarSeatsNoMaxValue)
            .WithMessage($"Maximum value for number of seats is {CarSeatsNoMaxValue}");
        RuleFor(c => c.Airbags)
            .GreaterThanOrEqualTo(CarAirbagsNoMinValue)
            .WithMessage($"Minimum value for number of airbags is {CarAirbagsNoMinValue}")
            .LessThan(CarAirbagsNoMaxValue)
            .WithMessage($"Maximum value for number of airbags is {CarAirbagsNoMaxValue}");
        RuleFor(c => c.FuelConsumption)
            .MaximumLength(CarFuelConsumptionMaxLength)
            .WithMessage($"Maximum length for fuel consumption is {CarFuelConsumptionMaxLength}");
        RuleFor(c => c.Price)
            .GreaterThanOrEqualTo(CarPricePerDayMinValue)
            .WithMessage($"Minimum value for price is {CarPricePerDayMinValue}");
        RuleFor(c => c.Description)
            .MaximumLength(CarDescriptionMaxLength)
            .WithMessage($"Maximum length for description is {CarDescriptionMaxLength}");
    }
}
