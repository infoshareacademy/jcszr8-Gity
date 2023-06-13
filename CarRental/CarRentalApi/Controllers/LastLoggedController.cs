using CarRental.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

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

    [HttpGet("{id}/{from}/{to}")]
    public async Task<IEnumerable<LastLoggedReportDTO>> GetByIdAndDateAsync(int id, DateTime from, DateTime to)
    {
        var visitedCarsReport = await _reportApiService.GetLastLoggerdByIdAndDateAsync(id, from, to);
        return visitedCarsReport.ToList();
    }
}
