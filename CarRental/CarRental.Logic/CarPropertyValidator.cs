using CarRental.DAL.Enums;
using System.Diagnostics;

namespace CarRental.Logic;

public sealed class CarPropertyValidator
{
    public static bool IsCarPropertyValid(string propertyName, string propertyValue)
    {
        switch (propertyName)
        {
            case "make":
                return IsCarMakeValid(propertyValue);
            case "model":
                return IsCarModelValid(propertyValue);
            case "license-plate-number":
                return IsCarLicensePlateNumberValid(propertyValue);
            case "year":
                return IsCarYearValid(propertyValue);
            case "kilometrage":
                return IsKilometrageValid(propertyValue);
            case "airbags":
                return IsAirbagsNumberValid(propertyValue);
            case "seats":
                return IsSeatsNumberValid(propertyValue);
            case "doors":
                return IsDoorsNumberValid(propertyValue);
            case "price":
                return IsPriceValid(propertyValue);
            case "color":
                return IsColorValid(propertyValue);
            case "fuel-consumption":
                return IsFuelConsumptionValid(propertyValue);
            case "transmission":
                return IsTransmissionTypeValid(propertyValue);
            case "ac":
                return IsAcValid(propertyValue);
            case "displacement":
                return IsDisplacementValid(propertyValue);
            case "fuel-type":
                return IsFuelTypeValid(propertyValue);
            case "kw":
                return IsPowerInKwValid(propertyValue);
            case "vin":
                return IsVinValid(propertyValue);
            default:
                return false;
        }
    }

    public static bool IsCarLicensePlateNumberValid(string licensePlateNumber)
    {
        // TODO better validation, ex. against some chars like {$%^! etc.
        if (licensePlateNumber.Length >= 4 && licensePlateNumber.Length <= 10)
            return true;
        return false;
    }
    public static bool IsCarMakeValid(string carMake)
    {
        // TODO better validation, ex. against some list of car makers
        if (carMake.Length >= 3 && carMake.Length < 30)
            return true;
        return false;
    }

    public static bool IsCarModelValid(string carModel)
    {
        // TODO better validation, ex. against some list of car models
        if (carModel.Length >= 3 && carModel.Length < 30)
            return true;
        return false;
    }

    public static bool IsCarYearValid(string year)
    {
        return int.TryParse(year, out int y)
            && (y >= 2000 && y <= DateTime.Now.Year);
    }

    public static bool IsKilometrageValid(string kilometrage)
    {
        return int.TryParse(kilometrage, out int k)
            && (k >= 0 && k <= 1_000_000);
    }

    public static bool IsAirbagsNumberValid(string airbags)
    {
        return int.TryParse(airbags, out int a)
            && (a >= 0 && a <= 20);
    }

    public static bool IsDoorsNumberValid(string doors)
    {
        return int.TryParse(doors, out int d)
            && (d >= 3 && d <= 10);
    }

    public static bool IsSeatsNumberValid(string seats)
    {
        return int.TryParse(seats, out int s)
            && (s >= 2 && s <= 30);
    }

    public static bool IsPriceValid(string price)
    {
        return decimal.TryParse(price, out decimal p)
            && (p >= 0 && p <= 600);
    }

    //fuel kw
    public static bool IsColorValid(string color)
    {
        return color.Length >= 3 && color.Length < 20;
    }

    public static bool IsFuelTypeValid(string fuelType)
    {
        var isParsed = Enum.TryParse<EngineType>(fuelType, out var parsed);
        return isParsed;
    }

    public static bool IsTransmissionTypeValid(string transmissionType)
    {
        bool isParsed = 
            Enum.TryParse<TransmissionType>(transmissionType, out TransmissionType tt);
        return isParsed;
    }

    public static bool IsVinValid(string vin)
    {
        // TODO real validation
        return vin.Length >= 10 && vin.Length <= 20;
    }

    public static bool IsAcValid(string ac)
    {
        // TODO
        return true;
    }

    public static bool IsDisplacementValid(string displacement)
    {
        return displacement.Length >= 1 && displacement.Length <= 10;
    }

    public static bool IsPowerInKwValid(string kilowats)
    {
        return float.TryParse(kilowats, out float k)
            && (k >= 50 && k <= 500);
    }

    public static bool IsFuelConsumptionValid(string fuelConsumption)
    {
        // TODO improve this validation
        return fuelConsumption.Length >= 3 && fuelConsumption.Length <= 10;
    }
}
