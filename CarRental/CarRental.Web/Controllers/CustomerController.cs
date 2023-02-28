using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.Logic.Services;
using Microsoft.AspNetCore.Http;
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
    public ActionResult Index()
    {
        var model = _customerService.GetAll();
        return View(model);
    }

    // GET: CustomerController/Details/5
    public ActionResult Details(int id)
    {
        var model = _customerService.GetById(id);
        return View(model);
    }

    // GET: CustomerController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CustomerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Customer customer)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _customerService.Create(customer);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            return View();
        }
    }

    // GET: CustomerController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
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

    // GET: CustomerController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CustomerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
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
