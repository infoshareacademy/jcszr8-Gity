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
}
