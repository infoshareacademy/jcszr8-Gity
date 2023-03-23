using CarRental.Logic.Services.IServices;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly ICarService   _carService;
        public SearchController(ISearchService searchService,ICarService carService)
        {
            _searchService = searchService;
            _carService = carService;
        }

        // GET: SearchController
        public IActionResult Index()
        {
            var model = new SearchViewModel()
            {
                Cars = _carService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchFromHome(SearchViewModel search)
        {
            var dto = search.SearchDto;
            var cars = _searchService.SearchList(dto);
            search.Cars = cars;
            return View(search);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(SearchViewModel search)
        {
            var dto = search.SearchDto;
            var model = _searchService.FilterList(dto);
            search.Cars= model;
            return View(search);
        }
    }
}
