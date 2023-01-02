namespace CarRental.DAL.Utilities;
public static class DateTimeFormatter
{
    public static bool TryParseDateStringYYYY_MM_DDToDateOnly(string dateString, out DateOnly dateOnly)
    {
        try
        {
            int year = int.Parse(dateString.Substring(0, 4));
            int month = int.Parse(dateString.Substring(5, 2));
            int day = int.Parse(dateString.Substring(8, 2));

            dateOnly = new DateOnly(year, month, day);
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
    }

    public static bool TryParseStringYYYY_MM_DDTHH_MMToDateTime(string dateTimeString, out DateTime dateTime)
    {
        try
        {
            int year = int.Parse(dateTimeString.Substring(0, 4));
            int month = int.Parse(dateTimeString.Substring(5, 2));
            int day = int.Parse(dateTimeString.Substring(8, 2));
            int hour = int.Parse(dateTimeString.Substring(11, 2));
            int minute = int.Parse(dateTimeString.Substring(14, 2));

            dateTime = new DateTime(year, month, day, hour, minute, 0);
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            dateTime = default;
            return false;
        }
    }
}
