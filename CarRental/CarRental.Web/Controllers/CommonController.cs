using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers;

public class CommonController : Controller
{
    private readonly ICommonService _commonService;
    private readonly ICarService _carService;

    public CommonController(ICommonService commonService, ICarService carService)
    {
        _commonService = commonService;
        _carService = carService;
    }

    public IActionResult Index()
    {
        var temp = DateTime.Now;
        var beginDate = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 0);
        var model = new SearchViewModel()
        {
            Cars = _carService.GetAll(),
            SearchDto = new SearchFieldsModel()
            {
                StartDate = beginDate,
                EndDate = beginDate.AddDays(1)
            }
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(SearchViewModel search)
    {
        var dto = search.SearchDto;
        var model = _commonService.FilterList(dto);
        search.Cars = model;
        return View(nameof(Index), search);
    }
}
