using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Models;
public class GenerateReportViewModel
{
    public int UserId { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public IEnumerable<VisitedCarViewModel>? VisitedCars { get; set; } = new List<VisitedCarViewModel>();
    public IEnumerable<LastLoggedReportDTO>? LastLoggedReports { get; set; } = new List<LastLoggedReportDTO>();
}
