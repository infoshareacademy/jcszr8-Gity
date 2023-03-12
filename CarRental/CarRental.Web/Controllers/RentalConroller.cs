using CarRental.Logic.Interfaces;
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

        var model = new List<RentalListModel>();

        foreach(var rental in rentals)
        {
            model.Add(new RentalListModel().FillModel(rental));
        }

        return View(model);
    }

    // GET: RentalConroller/Details/5
    public IActionResult Details(int id)
    {
        return View();
    }

    // GET: RentalConroller/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RentalConroller/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(IFormCollection collection)
    {
        try
        {
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
        return View();
    }

    // POST: RentalConroller/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
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
        return View();
    }

    // POST: RentalConroller/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
