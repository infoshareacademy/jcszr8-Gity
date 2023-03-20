using CarRental.DAL.Models;
using CarRental.Logic.Interfaces;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        this._customerService = customerService ??
            throw new ArgumentNullException(nameof(customerService));
    }

    // GET: CustomerController
    public IActionResult Index()
    {
        var customers = _customerService.GetAll();

        var model = new List<CustomerViewModel>();

        foreach (var customer in customers)
        {
            model.Add(new CustomerViewModel().FillModel(customer));
        }
        return View(model);
    }

    // GET: CustomerController/Details/5
    public IActionResult Details(int id)
    {
        var customer = _customerService.GetById(id);

        if (customer is null)
            return RedirectToAction(nameof(Index));

        var model = new CustomerViewModel().FillModel(customer);

        return View(model);
    }

    // GET: CustomerController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CustomerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CustomerViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = model.FillEntity();

            _customerService.Create(customer);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            return View();
        }
    }

    // GET: CustomerController/Edit/5
    public IActionResult Edit(int id)
    {
        var customer = _customerService.GetById(id);
        var model = new CustomerViewModel().FillModel(customer);

        return View(model);
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CustomerViewModel model)
    {
        try
        {
            var customer = model.FillEntity();

            _customerService.Update(customer);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CustomerController/Delete/5
    public IActionResult Delete(int id)
    {
        var customer = _customerService.GetById(id);

        var model = new CustomerViewModel().FillModel(customer);

        return View(model);
    }

    // POST: CustomerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _customerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
