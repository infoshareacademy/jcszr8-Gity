using Microsoft.AspNetCore.Mvc;

namespace CarRental.Logic.Models;

public class GeneratedReportViewModel
{
    public int UserIdFromLastLogged { get; set; }
    public DateTime LastLogged { get; set; }
    public int UserIdFromVisitedCars { get; set; }
    public int CarId { get; set; }
    public DateTime DateWhenClicked { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicencePlate { get; set; }

    public List<VisitedCarViewModel> VisitedCars { get; set; }
    public List<LastLoggedReportDTO> LastLoggedReports { get; set; }
}
