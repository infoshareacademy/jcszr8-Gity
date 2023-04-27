namespace CarRental.Common.Extensions;

public static class Extensions
{
    public static string DefaultDateFormat(this DateTime dateTime)
    {
        return Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd hh:mm ");
    }

    public static string RemoveWhitespaces(this string input)
    {
        var temp = input.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray();
        return new string(temp);
    }
}
