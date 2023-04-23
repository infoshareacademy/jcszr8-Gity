using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;
    private readonly ISearchService _searchService;

    public CarController(ICarService carService, ISearchService searchService)
    {
        _carService = carService;
        _searchService = searchService;
    }

    // GET: CarController
    public IActionResult Index()
    {
        var cars = this._carService.GetAll();
        return View(cars);
    }

    // GET: CarController/Details/5
    public IActionResult Details(int id)
    {
        var car = _carService.Get(id);
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

            return RedirectToAction("Index", "Search"); ;
        }
        catch
        {
            return View();
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
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CarController/Delete/5
    public IActionResult Delete(int id)
    {
        var car = _carService.Get(id);
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
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
