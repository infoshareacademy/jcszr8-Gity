using CarRental.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services.IServices;
public interface IReportApiService
{
    Task Create(VisitedCarViewModel model);
    Task<IEnumerable<VisitedCarViewModel>> GetByIdAndDateAsync(int id, DateTime from, DateTime to);
}
