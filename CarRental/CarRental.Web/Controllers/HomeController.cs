using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarRental.Logic.Services.IServices;

namespace CarRental.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerService _customerService;
    private readonly ICarService _carService;

    public HomeController(ILogger<HomeController> logger, ICustomerService customerService, ICarService carService)
    {
        _logger = logger;
        _customerService = customerService;
        _carService = carService;
    }

    public IActionResult Index()
    {
         //this._customerService.Create("Imie", "Nazwisko", "+48111222333");
         var cars = new SearchViewModel();
         cars.Cars = _carService.GetAll();
        return View(cars);
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