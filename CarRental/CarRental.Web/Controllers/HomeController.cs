using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarRental.Logic.Interfaces;

namespace CarRental.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly  ICarService _carService;

    public HomeController(ILogger<HomeController> logger, ICarService carService)
    {
        _logger = logger;
        _carService = carService;
    }

    public IActionResult Index()
    {
        var model = new SearchViewModel()
        {
            Cars = _carService.GetAll()
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}