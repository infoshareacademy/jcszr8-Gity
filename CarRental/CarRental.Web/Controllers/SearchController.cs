using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly ICarService _carService;
        public SearchController(ISearchService searchService, ICarService carService)
        {
            _searchService = searchService;
            _carService = carService;
        }

        // GET: SearchController
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
            var model = _searchService.FilterList(dto);
            search.Cars = model;
            return View("Index", search);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchFromHome(SearchViewModel search)
        {
            var dto = search.SearchDto;
            var cars = _searchService.SearchList(dto);
            search.Cars = cars;
            return View("Index", search);
        }
    }
}
