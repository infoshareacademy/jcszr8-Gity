using AutoMapper;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class RentalController : Controller
{
    private readonly IRentalService _rentalService;
    private readonly ICustomerService _customerService;
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public RentalController(IRentalService rentalService, IMapper mapper, ICustomerService customerService, ICarService carService)
    {
        _rentalService = rentalService;
        _mapper = mapper;
        _customerService = customerService;
        _carService = carService;
    }
    // GET: RentalConroller
    public IActionResult Index()
    {
        var rentals = _rentalService.GetAll();
        var rentalModels = _mapper.Map<List<RentalModel>>(rentals);

        List<RentalViewModel> model = new();

        foreach (var rental in rentals)
        {
            var customerName = _customerService.Get(rental.CustomerId).FirstName
                + " " + _customerService.Get(rental.CustomerId).LastName;

            var carLicencePlate = _carService.Get(rental.CarId).LicencePlateNumber;

            model.Add(new RentalViewModel
            {
                Id = rental.Id,
                CarId = rental.CarId,
                CustomerId = rental.CustomerId,
                BeginDate = rental.BeginDate,
                EndDate = rental.EndDate,
                TotalCost = rental.TotalCost,
                CustomerName = customerName,
                CarLicencePlate = carLicencePlate,
            });
        }

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
