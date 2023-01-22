namespace CarRental.DAL.Utilities;

public sealed class Utilities
{
    public DateTime TimestampToDateTime(string timestamp)
    {
        var isValidDate = DateTime.TryParse(timestamp, out var parsedTime);

        if (isValidDate)
        {
            return parsedTime;
        }
        throw new ArgumentException($"Wrong format of timestamp: {timestamp}");
    }
}
