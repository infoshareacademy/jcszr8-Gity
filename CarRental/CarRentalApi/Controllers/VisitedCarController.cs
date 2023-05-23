using CarRental.DAL.Context;
using CarRental.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitedCarController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly ILogger<VisitedCarController> _logger;
    public VisitedCarController(ILogger<VisitedCarController> logger, ApplicationContext context)
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
