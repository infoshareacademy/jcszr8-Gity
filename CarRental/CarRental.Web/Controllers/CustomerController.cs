using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET: CustomerController
    public IActionResult Index()
    {
        var customers = _customerService.GetAll();
        return View(customers);
    }

    // GET: CustomerController/Details/5
    public IActionResult Details(int id)
    {
        var customer = _customerService.Get(id);

        if (customer is null)
            return RedirectToAction(nameof(Index));

        return View(customer);
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

            _customerService.Create(model);

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
        var customer = _customerService.Get(id);
        return View(customer);
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CustomerViewModel customer)
    {
        try
        {
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
        var customer = _customerService.Get(id);
        return View(customer);
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
