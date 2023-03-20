using CarRental.DAL.Models;
using CarRental.Logic.Interfaces;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;
    private readonly ISearchService _searchService;

    public CarController(ICarService carService, ISearchService searchService)
    {
        this._carService = carService;
        this._searchService = searchService;
    }

    // GET: CarController
    public IActionResult Index()
    {
        var cars = this._carService.GetAll();

        var model = new List<CarViewModel>();

        foreach (var car in cars)
        {
            model.Add(new CarViewModel().FillModel(car));
        }
        return View(model);
    }

    // GET: CarController/Details/5
    public IActionResult Details(int id)
    {
        var car = _carService.GetById(id);

        var model = new CarViewModel().FillModel(car);

        return View(model);
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

            var newCar = model.FillEntity();

            _carService.Create(newCar);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CarController/Edit/5
    public IActionResult Edit(int id)
    {
        var car = _carService.GetById(id);

        var model = new CarViewModel().FillModel(car);

        return View(model);
    }

    // POST: CarController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CarViewModel model)
    {
        try
        {
            var car = model.FillEntity();
            _carService.Update(car);

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
        var car = _carService.GetById(id);

        var model = new CarViewModel().FillModel(car);

        return View(model);
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
