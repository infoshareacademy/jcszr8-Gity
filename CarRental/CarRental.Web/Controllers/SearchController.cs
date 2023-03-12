using CarRental.DAL.Models;
using CarRental.Logic;
using CarRental.Logic.Services;
using CarRental.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
                Cars = _carService.GetAll(),
                SearchViewModelDto = new SearchViewModelDto()
                {
                    EndDate = DateTime.Now,
                    ModelAndMake = "asd",
                    StartDate = DateTime.Now.AddDays(-7),
                    ProductionYearFrom = 0,
                    ProductionYearTo = 0,
                }

            };
            return View(model);
        }

        // GET: SearchController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Cops(SearchViewModel searchViewModel)
        {

            return View(searchViewModel.SearchViewModelDto);
        }
        
    }
}
