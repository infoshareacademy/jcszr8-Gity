using CarRental.DAL.Models;
using CarRental.Logic.Interfaces;
using CarRental.Logic.Services;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class RentalController : Controller
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
    {
        this._rentalService = rentalService;
    }
    // GET: RentalConroller
    public IActionResult Index()
    {
        var rentals = _rentalService.GetAll();

        var model = new List<RentalViewModel>();

        foreach(var rental in rentals)
        {
            model.Add(new RentalViewModel().FillModel(rental));
        }

        return View(model);
    }

    // GET: RentalConroller/Details/5
    public IActionResult Details(int id)
    {
        var rental = _rentalService.GetById(id);
        var model = new RentalListModel().FillModel(rental);
        return View(model);
    }

    // GET: RentalConroller/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RentalConroller/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Rental rental)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            _rentalService.Create(rental);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RentalConroller/Edit/5
    public IActionResult Edit(int id)
    {
        var rental = _rentalService.GetById(id);
        return View(rental);
    }

    // POST: RentalConroller/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Rental rental)
    {
        try
        {
            _rentalService.Update(rental);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RentalConroller/Delete/5
    public IActionResult Delete(int id)
    {
        var rental = _rentalService.GetById(id);
        return View(rental);
    }

    // POST: RentalConroller/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _rentalService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
