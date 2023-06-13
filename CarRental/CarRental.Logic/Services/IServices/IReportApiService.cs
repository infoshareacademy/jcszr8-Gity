using CarRental.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services.IServices;
public interface IReportApiService
{
    Task CreateVisitedCarAsync(VisitedCarViewModel model);
    Task CreateLastLoggedAsync(LastLoggedReportDTO model);
    Task<IEnumerable<VisitedCarViewModel>> GetVisitedCarByIdAndDateAsync(int id, DateTime from, DateTime to);
    Task<IEnumerable<LastLoggedReportDTO>> GetLastLoggerdByIdAndDateAsync(int id, DateTime from, DateTime to);
}
