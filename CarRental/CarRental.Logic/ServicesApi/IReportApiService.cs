using CarRental.Logic.Models;

namespace CarRental.Logic.ServicesApi;
public interface IReportApiService
{
    Task CreateVisitedCarAsync(VisitedCarViewModel model);
    Task CreateLastLoggedAsync(LastLoggedReportDTO model);
    Task<IEnumerable<VisitedCarViewModel>> GetVisitedCarByIdAndDateAsync(int id, DateTime from, DateTime to);
    Task<IEnumerable<LastLoggedReportDTO>> GetLastLoggerdByIdAndDateAsync(int id, DateTime from, DateTime to);
    Task<IEnumerable<VisitedCarViewModel>> GetDailyVisitedCar();
    Task<IEnumerable<LastLoggedReportDTO>> GetDailyLastLogged();
}
