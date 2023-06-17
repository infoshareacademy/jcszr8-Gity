using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IReportService
{
    Task ReportCarVisitAsync(CarViewModel visitedCar, string userId);
    Task ReportUserLoginAsync(string email);
    Task<IEnumerable<object>> GetReportsAsync(int userId, DateTime from, DateTime to, string reportType);
    Task<GeneratedReportViewModel> GetDailyReport();

}
