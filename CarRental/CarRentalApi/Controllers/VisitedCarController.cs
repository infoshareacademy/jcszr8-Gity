using AutoMapper;
using CarRental.DAL.Context;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitedCarController : ControllerBase
{
    private readonly ILogger<VisitedCarController> _logger;
    private readonly IReportApiService _reportApiService;
    public VisitedCarController(ILogger<VisitedCarController> logger, IReportApiService reportApiService)
    {
        _logger = logger;
        _reportApiService = reportApiService;
    }

    [HttpPost(Name = "AddVisitedCar")]
    public async Task AddAsyncVisit([FromBody] VisitedCarViewModel lastLoggedReport)
    {
        await _reportApiService.CreateVisitedCarAsync(lastLoggedReport);
    }

    [HttpGet("{id}/{from}/{to}")]
    public async Task<IEnumerable<VisitedCarViewModel>> GetByIdAndDateAsync(int id, DateTime from, DateTime to)
    {
        var visitedCarsReport = await _reportApiService.GetVisitedCarByIdAndDateAsync(id, from, to);
        return visitedCarsReport.ToList();
    }
}
