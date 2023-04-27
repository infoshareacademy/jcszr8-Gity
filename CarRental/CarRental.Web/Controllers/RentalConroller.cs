using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CarRental.Web.Controllers;

public class RentalController : Controller
{
    private readonly IRentalService _rentalService;
    private readonly ICustomerService _customerService;
    private readonly ICarService _carService;

    public RentalController(IRentalService rentalService, ICustomerService customerService, ICarService carService)
    {
        _customerService = customerService;
        _carService = carService;
        _rentalService = rentalService;
    }
    // GET: RentalConroller
    public IActionResult Index()
    {
        var rentals = _rentalService.GetAll();

        List<RentalViewModel> model = new();

        foreach (var rental in rentals)
        {
            var customerName = _customerService?.Get(rental.CustomerId)?.FirstName
                + " " + _customerService?.Get(rental.CustomerId)?.LastName;

            var carLicencePlate = _carService?.Get(rental.CarId)?.LicencePlateNumber;

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
        dynamic d = GetShortCustomers().FirstOrDefault<object>(rental.CustomerId);
        object shortCustomer = d.FirstName + " " + d.LastName;

        var carLicencePlate = _carService?.Get(rental.CarId)?.LicencePlateNumber;

        var rentalViewModel = new RentalViewModel
        {
            Id = rental.Id,
            CarId = rental.CarId,
            CustomerId = rental.CustomerId,
            BeginDate = rental.BeginDate,
            EndDate = rental.EndDate,
            TotalCost = rental.TotalCost,

            CustomerName = shortCustomer.ToString(),
            CarLicencePlate = carLicencePlate,
        };

        return View(rentalViewModel);
    }

    // GET: RentalConroller/Create
    public IActionResult Create()
    {
        var shortCustomers = GetShortCustomers();
        var shortCars = GetShortCars();
        var temp = DateTime.Now;
        var beginDate = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 1);

        var model = new RentalCreateViewModel
        {
            Customers = shortCustomers,
            Cars = shortCars,
            BeginDate = beginDate,
            EndDate = beginDate.AddDays(1),
            TotalCost = 0m
        };

        return View(model);
    }

    // POST: RentalConroller/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RentalCreateViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rentalModel = new RentalViewModel
            {
                CarId = model.CarId,
                CustomerId = model.CustomerId,
                BeginDate = model.BeginDate,
                EndDate = model.EndDate,
                TotalCost = model.TotalCost,
            };

            decimal carPricePerDay = (decimal)_carService!.Get(model.CarId)!.Price;
            rentalModel.TotalCost = _rentalService.GetRentalTotalPrice(carPricePerDay, rentalModel.BeginDate, rentalModel.EndDate);

            _rentalService.Create(rentalModel);

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
        var shortCustomers = GetShortCustomers();
        var shortCars = GetShortCars();

        var model = new RentalCreateViewModel
        {
            Id = rentalModel.Id,
            CarId = rentalModel.CarId,
            CustomerId = rentalModel.CustomerId,
            BeginDate = rentalModel.BeginDate,
            EndDate = rentalModel.EndDate,
            TotalCost = (decimal)rentalModel.TotalCost,

            Customers = shortCustomers,
            Cars = shortCars,
        };
        return View(model);
    }

    // POST: RentalConroller/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(RentalViewModel model)
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

    private List<object> GetShortCustomers()
    {
        return _customerService.GetAll().Select(x => new { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList<object>();
    }

    private List<object> GetShortCars()
    {
        return _carService.GetAll().Select(x => new { x.Id, x.LicencePlateNumber, x.Make, x.CarModelProp }).ToList<object>();
    }
    public decimal GetTotalCost(int carId, DateTime? beginDate = null, DateTime? endDate = null)
    {
        if (beginDate == null || endDate == null)
        {
            return 0m;
        }
        var carPricePerDay = _carService.Get(carId).Price;
        var total = _rentalService.GetRentalTotalPrice((decimal)carPricePerDay, (DateTime)beginDate, (DateTime)endDate);
        return Math.Round(total, 2, MidpointRounding.ToZero);
    }
}
