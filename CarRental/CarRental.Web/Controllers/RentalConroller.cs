using AutoMapper;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class RentalController : Controller
{
    private readonly IRentalService _rentalService;
    private readonly IMapper _mapper;

    public RentalController(IRentalService rentalService, IMapper mapper)
    {
        _rentalService = rentalService;
        _mapper = mapper;
    }
    // GET: RentalConroller
    public IActionResult Index()
    {
        var rentals = _rentalService.GetAll();
        var model = _mapper.Map<List<RentalModel>>(rentals);

        return View(model);
    }

    // GET: RentalConroller/Details/5
    public IActionResult Details(int id)
    {
        var rental = _rentalService.Get(id);
        var model = _mapper.Map<RentalModel>(rental);

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
    public IActionResult Create(RentalModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rental = _mapper.Map<RentalModel>(model);
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
        var rentalModel = _rentalService.Get(id);
        return View(rentalModel);
    }

    // POST: RentalConroller/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(RentalModel model)
    {
        try
        {
            _rentalService.Update(model);
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
        var rental = _rentalService.Get(id);
        var model = _mapper.Map<RentalModel>(rental);

        return View(model);
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
