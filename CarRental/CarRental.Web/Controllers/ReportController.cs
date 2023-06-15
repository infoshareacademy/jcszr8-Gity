using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class ReportController : Controller
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    public IActionResult Index()
    {
        var model = new GenerateReportViewModel()
        {
            From = DateTime.Now,
            To = DateTime.Now.AddDays(1),
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(GenerateReportViewModel reportModel)
    {
        if (ModelState.IsValid)
        {

            var report = await _reportService.GetReportsAsync(reportModel.UserId, reportModel.From, reportModel.To,
                 reportModel.ReportType);

            reportModel.Reports = report;
            return View(reportModel);
        }

        return View(reportModel);
    }
}
