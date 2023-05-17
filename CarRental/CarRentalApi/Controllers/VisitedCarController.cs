using CarRentalApi.Context;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitedCarController : ControllerBase
{
    private readonly CarRentalApiContext _context;
    private readonly ILogger<ReportController> _logger;
    public VisitedCarController(ILogger<ReportController> logger, CarRentalApiContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost(Name = "AddVisitedCar")]
    public async Task AddAsyncVisit([FromBody] VisitedCar lastLoggedReport)
    {
        var existingRow = await _context.VisitedCars
            .FirstOrDefaultAsync<VisitedCar>(x => x.UserId == lastLoggedReport.UserId);

        if (existingRow != null)
        {
            _context.VisitedCars.Update(lastLoggedReport);
            await _context.SaveChangesAsync();
            return; 
        }
        await _context.AddAsync(lastLoggedReport);
        await _context.SaveChangesAsync();
    }
}
