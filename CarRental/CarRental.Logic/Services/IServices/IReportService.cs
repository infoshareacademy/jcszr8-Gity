using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IReportService
{
    Task ReportCarVisit(CarViewModel visitedCar,int userId);
}
