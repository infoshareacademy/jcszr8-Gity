using AutoMapper;
using CarRental.DAL.Models;
using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    // GET: CustomerController
    public IActionResult Index()
    {
        var customers = _customerService.GetAll();

        var model = _mapper.Map<List<CustomerViewModel>>(customers);

        return View(model);
    }

    // GET: CustomerController/Details/5
    public IActionResult Details(int id)
    {
        var customer = _customerService.Get(id);

        if (customer is null)
            return RedirectToAction(nameof(Index));

        var model = _mapper.Map<CustomerViewModel>(customer);

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

            var customer = _mapper.Map<CustomerModel>(model);

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
        var customer = _customerService.Get(id);

        var model = _mapper.Map<CustomerViewModel>(customer);

        return View(model);
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CustomerViewModel model)
    {
        try
        {
            var customer = _mapper.Map<CustomerModel>(model);

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

        var model = _mapper.Map<CustomerViewModel>(customer);

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
