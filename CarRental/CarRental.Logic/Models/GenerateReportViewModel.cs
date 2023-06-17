namespace CarRental.Logic.Models;
public class GenerateReportViewModel
{
    public int UserId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string ReportType { get; set; }
    public IEnumerable<object> Reports { get; set; } = new List<object>();
    
}
