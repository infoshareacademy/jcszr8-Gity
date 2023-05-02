namespace CarRental.Common;
public static class AppConfig
{
    // Development settings - for testing purposes
    public const bool UsePeselChecksumValidation = false;

    // For Customer
    public const int FirstNameMaxLength = 30;
    public const int LastNameMaxLength = 50;
    public const int EmailAddressMaxLength = 100;
    public const int PeselLength = 11;
    public const int PhoneNumberMinLength = 9;
    public const int PhoneNumberMaxLength = 50;

    // For Car
    public const int CarMakeMaxLength = 20;
    public const int CarModelMaxLength = 20;
    public const int CarLicencePlateNumberMinLength = 2;
    public const int CarLicencePlateNumberMaxLength = 8;
    public const int CarKilometrageMinValue = 0;
    public const int CarKilometrageMaxValue = 500_000;
    public const int CarDoorsNoMinValue = 2;
    public const int CarDoorsNoMaxValue = 10;
    public const int CarSeatsNoMinValue = 2;
    public const int CarSeatsNoMaxValue = 50;
    public const int CarAirbagsNoMinValue = 0;
    public const int CarAirbagsNoMaxValue = 100;
    public const int CarFuelConsumptionMaxLength = 100;
    public const int CarDisplacementMaxLength = 10;
    public static readonly int CarYearMinValue = DateTime.Now.Year - 15;
    public static readonly int CarYearMaxValue = DateTime.Now.Year;
    public const int CarDescriptionMaxLength = 1000;
    public const decimal CarPricePerDayMinValue = 40;
    public const float CarPowerInKiloWatsMinValue = 60;
    public const float CarPowerInKiloWatsMaxValue = 1000;

    // For Rental
    public const int RentalMinDays = 1;
    public const int RentalMaxDays = 90;
}
