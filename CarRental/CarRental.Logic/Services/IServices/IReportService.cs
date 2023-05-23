using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IReportService
{
    Task ReportCarVisitAsync(CarViewModel visitedCar, string userId);
    Task ReportUserLoginAsync(int userId);
    Task<int> GetUserIdAsync(string email);
}
