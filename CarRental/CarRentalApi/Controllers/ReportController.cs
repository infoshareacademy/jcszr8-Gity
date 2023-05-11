using CarRentalApi.Context;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("{id}", Name = "GetLastLogged")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LastLoggedReport))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLastLoggedAsync(int id)
    {
        var lastLogged = await _context.LastLoggings.FirstOrDefaultAsync(x => x.Id == id);
        return lastLogged is null ? NotFound() : Ok(lastLogged);
    }


    //[HttpGet("{id}", Name = "GetLastLogged2")]
    //public async Task<LastLoggedReport> GetLastLoggedAsync2(int id)
    //{
    //    var lastLogged = await _context.LastLoggings.FirstOrDefaultAsync(x => x.Id == id);
    //    return lastLogged;
    //}




    [HttpGet(Name = "GetAllLastLogged")]
    public async Task<IEnumerable<LastLoggedReport>> GetAllLastLogged()
    {
        var allLastLogged = await _context.LastLoggings.ToListAsync();
        return allLastLogged;
    }

    [HttpPost(Name = "AddLastLogged")]
    public async Task AddAsync([FromBody] LastLoggedReport lastLoggedReport)
    {
        var existingRow = await _context.LastLoggings
            .FirstOrDefaultAsync(x => x.UserId == lastLoggedReport.UserId);

        if (existingRow != null)
        {
            await UpdateAsync(lastLoggedReport);
            return;
        }
        await _context.AddAsync(lastLoggedReport);
        await _context.SaveChangesAsync();
    }

    //[HttpPost(Name = "AddLastLogged2")]
    //public async Task AddAsync2([FromBody] LastLoggedReport lastLoggedReport)
    //{
    //    var existingRow = await _context.LastLoggings
    //        .FirstOrDefaultAsync(x => x.UserId == lastLoggedReport.UserId);
    //    if (existingRow != null)
    //    {
    //        await UpdateAsync(lastLoggedReport);
    //    }
    //    else
    //    {
    //        await _context.AddAsync(lastLoggedReport);
    //    }
    //    await _context.SaveChangesAsync();
    //}

    [HttpPut(Name = "UpdateLastLogged")]
    public async Task UpdateAsync([FromBody] LastLoggedReport lastLoggedReport)
    {
        //var lastLogged = await _context.LastLoggings.FirstOrDefaultAsync(x => x.UserId == lastLoggedReport.UserId);
        var lastLogged = await _context.LastLoggings.FindAsync(lastLoggedReport.UserId);
        if (lastLogged != null)
        {
            lastLogged.LastLogged = lastLoggedReport.LastLogged;
            await _context.SaveChangesAsync();
        }
    }
}
