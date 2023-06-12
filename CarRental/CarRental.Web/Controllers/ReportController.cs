using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class ReportController : Controller
{
    public readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(int userId, DateTime from , DateTime to)
    {
        var model = new GenerateReportViewModel();
        return View(model);
    }
}
