using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IReportService
{
    Task ReportCarVisit(CarViewModel visitedCar,string userId);
    Task ReportUserLogin(int userId);
    Task<int> GetUserIdAsync();
}
