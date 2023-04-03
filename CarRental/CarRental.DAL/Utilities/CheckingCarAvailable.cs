using CarRental.DAL.Entities;

namespace CarRental.DAL.Utilities;

public sealed class CheckingCarAvailable
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
    public bool IsCarAvailable(DateTime start, DateTime end, int carId, List<Rental> rentals)
    {
        bool result = false; 
        var rental = rentals.FirstOrDefault(r => r.CarId == carId);
        if (rental is null)
        {
            return true;
        }


        if (start > rental.BeginDate && end < rental.EndDate)
        {
            result = false;
        }
        return result;
    }
    public void RunIsCarAvailable()
    {
      //  var available = IsCarAvailable(new DateTime(2023, 1, 10), DateTime.Now, 4);

    }
}
