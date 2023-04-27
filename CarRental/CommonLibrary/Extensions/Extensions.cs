namespace CarRental.Common.Extensions;

public static class Extensions
{
    public static string DefaultDateFormat(this DateTime dateTime)
    {
        return Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd hh:mm ");
    }
}
