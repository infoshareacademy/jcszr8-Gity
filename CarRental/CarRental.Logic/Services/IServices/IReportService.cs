using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IReportService
{
    Task ReportCarVisitAsync(CarViewModel visitedCar, string userId);
    Task ReportUserLoginAsync(string email, int userId, DateTime from, DateTime to);
}
