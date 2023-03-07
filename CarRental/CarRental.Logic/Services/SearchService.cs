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
        public SearchService(ICarService carService)
        {
            _carService = carService;
        }
        public List<Car> SearchList(string search)
        {
            List<Car> results = new List<Car>();

            results.AddRange(_carService.CarByName(search));
            results.AddRange(_carService.CarByAddons(search));
            return results;
        }
    }
}
