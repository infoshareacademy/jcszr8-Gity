using CarRentalApi.Context;

namespace CarRentalApi.Models;

public class ReportDetails
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime LastLogged { get; set; }
    public Dictionary<DateTime, int> LogsNumberInDay { get; set; } = new Dictionary<DateTime, int>();
}

