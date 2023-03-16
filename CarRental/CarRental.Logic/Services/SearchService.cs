using CarRental.DAL;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Logic.Interfaces;

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
            var cars = _carService.GetByName(search.ModelAndMake);

            if (search.ProductionYearTo > 0 && search.ProductionYearTo >= search.ProductionYearFrom)
            {
                cars = cars.Where(c => c.Year >= search.ProductionYearFrom && c.Year <= search.ProductionYearTo).ToList();
            }
            IEnumerable<int> getCarId = _rentalService.GetAvailableCarIds(search.StartDate, search.EndDate);
            foreach (var item in cars)
            {
                if (getCarId.Any(x => x == item.Id))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        public List<Car> FilterList(SearchViewModelDto searchDto)
        {
            List<Car> cars = new List<Car>();

            if (searchDto.Makes.Values.Any(v => v == true))
            {
                var selectedMakes = searchDto.Makes.Where(m => m.Value == true).Select(m => m.Key);
                cars = CarRentalData.Cars.Where(c => selectedMakes.Contains(c.Make, StringComparer.CurrentCultureIgnoreCase)).ToList();
            }
            if (searchDto.ProductionYearFrom > 0 && searchDto.ProductionYearTo > 0)
            {
                cars = cars.Where(c => c.Year >= searchDto.ProductionYearFrom && c.Year <= searchDto.ProductionYearTo).ToList();
            }
            if (!string.IsNullOrEmpty(searchDto.Model))
            {
                cars = cars.Where(c => c.CarModel.Contains(searchDto.Model, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            return cars;
        }
    }
}
