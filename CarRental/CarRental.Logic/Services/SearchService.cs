using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services
{
    public class SearchService : ISearchService
    {
        private readonly ICarService _carService;
        private readonly IRentalService _rentalService;
        public SearchService(ICarService carService, IRentalService rentalService)
        {
            _carService = carService;
            _rentalService = rentalService;
        }
        public List<Car> SearchList(SearchViewModelDto search)
        {
            List<Car> results = new List<Car>();
            var cars = _carService.CarByName(search.ModelAndMake);

            if (search.ProductionYearTo > 0 && search.ProductionYearTo >= search.ProductionYearFrom)
            {
                cars = cars.Where(c => c.Year >= search.ProductionYearFrom && c.Year <= search.ProductionYearTo).ToList();
            }
            List<int> getCarId = _rentalService.GetAvailableCarIds(search.StartDate, search.EndDate);
            foreach (var item in cars)
            {
                if (getCarId.Exists(x => x == item.Id))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        //public List<Car> SearchMenu(SearchViewModelDto search) 
        //
        //    //List<Car> results = new List<Car>();
        //    var results = _carService.CarByMaker();
        //    return results;
        //}
    }
}
