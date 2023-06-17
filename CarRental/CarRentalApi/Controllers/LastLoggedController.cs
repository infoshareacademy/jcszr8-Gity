using Microsoft.AspNetCore.Mvc;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using CarRental.Logic.ServicesApi;

namespace CarRentalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LastLoggedController : ControllerBase
{
    private readonly IReportApiService _reportApiService;
    private readonly ILogger<LastLoggedController> _logger;

    public LastLoggedController(ILogger<LastLoggedController> logger, IReportApiService reportApiService)
    {
        _logger = logger;
        _reportApiService = reportApiService;
    }


    [HttpPost(Name = "AddLastLogged")]
    public async Task AddAsync([FromBody] LastLoggedReportDTO lastLoggedReport)
    {
        await _reportApiService.CreateLastLoggedAsync(lastLoggedReport);
    }

    [HttpGet]
    public async Task<IEnumerable<LastLoggedReportDTO>> GetDaily()
    {
        return await _reportApiService.GetDailyLastLogged();
    }

    [HttpGet("{id}/{from}/{to}")]
    public async Task<IEnumerable<LastLoggedReportDTO>> GetByIdAndDateAsync(int id, DateTime from, DateTime to)
    {
        var visitedCarsReport = await _reportApiService.GetLastLoggerdByIdAndDateAsync(id, from, to);
        return visitedCarsReport.ToList();
    }
}
