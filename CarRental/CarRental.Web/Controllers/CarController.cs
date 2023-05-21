using AutoMapper;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRental.Web.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;
    private readonly ICommonService _commonService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserActivityService _userActivityService;

    public CarController(ICarService carService, ICommonService commonService, IServiceProvider serviceProvider, IUserActivityService userActivityService)
    {
        _carService = carService;
        _commonService = commonService;
        _serviceProvider = serviceProvider;
        _userActivityService = userActivityService;
    }

    // GET: CarController
    public IActionResult Index()
    {
        var cars = _carService.GetAll();
        return View(cars);
    }

    // GET: CarController/Details/5
    public IActionResult Details(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        int userIdToInt;
        userIdToInt = int.Parse(userId);
        var car = _carService.Get(id);
        _userActivityService.OnDetailsButtonClicked(car, userIdToInt);
        return View(car);
    }

    // GET: CarController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CarController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CarViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _carService.Create(model);

            TempData["AlertText"] = "Car created successfully";
            TempData["AlertClass"] = AlertType.Success;
            return RedirectToAction(nameof(Index), "Home");
        }
        catch (ArgumentException)
        {
            TempData["AlertText"] = "Something went wrong";
            TempData["AlertClass"] = AlertType.Warning;
            return View(nameof(Create), model);
        }
    }

    // GET: CarController/Edit/5
    public IActionResult Edit(int id)
    {
        var carModel = _carService.Get(id);
        return View(carModel);
    }

    // POST: CarController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CarViewModel model)
    {
        try
        {
            _carService.Update(model);
            TempData["AlertText"] = "Car updated successfully";
            TempData["AlertClass"] = AlertType.Success;
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            TempData["AlertText"] = "Something went wrong";
            TempData["AlertClass"] = AlertType.Warning;
            return View(nameof(Edit), model);
        }
    }

    // GET: CarController/Delete/5
    public IActionResult Delete(int id)
    {
        var car = _carService.Get(id);
        TempData["AlertText"] = "You are in danger zone";
        TempData["AlertClass"] = AlertType.Warning;
        return View(car);
    }

    // POST: CarController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _carService.Delete(id);
            TempData["AlertText"] = "Car deleted successfully";
            TempData["AlertClass"] = AlertType.Success;
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
