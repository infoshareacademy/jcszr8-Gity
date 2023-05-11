using CarRentalApi.Context;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CarRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly CarRentalApiContext _context;
    private readonly ILogger<ReportController> _logger;

    public ReportController(ILogger<ReportController> logger, CarRentalApiContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetAllLastLogged")]
    public async Task<IEnumerable<LastLoggedReport>> Get()
    {
        var allLastLogged = await _context.LastLoggings.ToListAsync();
        return allLastLogged;
    }

    [HttpPost(Name = "AddLastLogged")]
    public async Task AddAsync([FromBody] LastLoggedReport lastLoggedReport)
    {
        var existingRow = await _context.LastLoggings
            .FirstOrDefaultAsync<LastLoggedReport>(x => x.UserId == lastLoggedReport.UserId);

        if (existingRow != null)
        {
            _context.LastLoggings.Update(lastLoggedReport);
            await _context.SaveChangesAsync();
            return; 
        }
        await _context.AddAsync(lastLoggedReport);
        await _context.SaveChangesAsync();
    }

    [HttpPut(Name = "UpdateLastLogged")]
    public void Update([FromBody] LastLoggedReport lastLoggedReport)
    {
        //_context.LastLoggings.Update(lastLoggedReport);
        //var lastLogged = _context.LastLoggings.Find(lastLoggedReport.Id);
        var lastLogged = _context.LastLoggings.FirstOrDefault(x => x.UserId == lastLoggedReport.UserId);
        lastLogged.LastLogged = lastLoggedReport.LastLogged;
        _context.SaveChanges();
    }
}
