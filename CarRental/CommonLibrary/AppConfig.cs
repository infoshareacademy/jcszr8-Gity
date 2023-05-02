namespace CarRental.Common;
public static class AppConfig
{
    // Development settings - for testing purposes
    public const bool UsePeselChecksumValidation = false;

    // For Customer
    public static readonly int FirstNameMaxLength = 30;
    public static readonly int LastNameMaxLength = 50;
    public static readonly int EmailAddressMaxLength = 100;
    public static readonly int PeselLength = 11;
    public static readonly int PhoneNumberMinLength = 9;
    public static readonly int PhoneNumberMaxLength = 50;

    // For Car
    public static readonly int CarMakeMaxLength = 20;
    public static readonly int CarModelMaxLength = 20;
    public static readonly int CarLicencePlateNumberMinLength = 3;
    public static readonly int CarLicencePlateNumberMaxLength = 8;
    public static readonly int CarMinKilometrage = 0;
    public static readonly int CarMaxKilometrage = 500_000;
    public static readonly int CarMinDoorsNo = 2;
    public static readonly int CarMaxDoorsNo = 10;
    public static readonly int CarMinSeatsNo = 2;
    public static readonly int CarMaxSeatsNo = 50;
    public static readonly int CarMinAirbagsNo = 0;
    public static readonly int CarMaxAirbagsNo = 100;
    public static readonly int CarFuelConsumptionMaxLength = 100;
    public static readonly int CarDisplacementMaxLength = 10;
    public static readonly int CarYearMinValue = 2000;
    public static readonly int CarYearMaxValue = DateTime.Now.Year;
    public static readonly int CarDescriptionMaxLength = 1000;
    public static readonly decimal CarPricePerDayMinValue = 40;

    // For Rental
    public static readonly int RentalMinDays = 1;
    public static readonly int RentalMaxDays = 90;
}
