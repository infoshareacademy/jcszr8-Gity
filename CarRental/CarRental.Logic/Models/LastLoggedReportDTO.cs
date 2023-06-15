namespace CarRental.Logic.Models;
public class LastLoggedReportDTO
{
    public int UserId { get; set; }
    public DateTime LastLogged { get; set; }
    public int LoginCount { get; set; }
}
