using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarRental.Common;
using System.Security.Claims;

namespace CarRental.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private readonly ICustomerService _customerService;
    private readonly ICarService _carService;

    public HomeController(ILogger<HomeController> logger, ICarService carService)
    {
        _logger = logger;
        //_customerService = customerService;
        _carService = carService;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Test");
        SecretReader.ReadSecrects();
        var temp = DateTime.Now;
        var model = new SearchViewModel()
        {
            Cars = _carService.GetAll(),
            SearchDto = new SearchFieldsModel()
            {
                StartDate = temp,
                EndDate = temp.AddDays(1)
            }
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
