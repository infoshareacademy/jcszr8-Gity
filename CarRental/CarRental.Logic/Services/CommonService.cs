using AutoMapper;
using CarRental.Common;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;
public class CommonService
{
    private readonly ICarService _carService;
    private readonly ICustomerService _customerService;
    private readonly IRentalService _rentalService;

    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CommonService(ICarService carService, ICustomerService customerService,
        IRentalService rentalService, IMapper mapper, ILogger logger)
    {
        _carService = carService;
        _customerService = customerService;

        _mapper = mapper;
        _logger = logger;
        _rentalService = rentalService;
    }

    public List<CarViewModel> SearchList(SearchFieldsModel sfModel)
    {
        // TODO refactor SearchList
        var wantedTerm = new Term(sfModel.StartDate, sfModel.EndDate);

        List<CarViewModel> results = new List<CarViewModel>();
        var cars = _carService.GetByName(sfModel.ModelAndMake);

        if (sfModel.ProductionYearTo > 0 && sfModel.ProductionYearTo >= sfModel.ProductionYearFrom)
        {
            cars = cars.Where(c => c.Year >= sfModel.ProductionYearFrom && c.Year <= sfModel.ProductionYearTo).ToList();
        }

        IEnumerable<int> carIds = _rentalService
            .GetCarsAvailableInTerm(wantedTerm)
            .Select(c => c.Id);

        foreach (var item in cars)
        {
            if (carIds.Any(x => x == item.Id))
            {
                results.Add(item);
            }
        }
        return results;
    }

    public List<CarViewModel> FilterList(SearchFieldsModel sfModel)
    {
        // TODO refactor FindCars()
        List<CarViewModel> carModels = _carService.GetAll().ToList();
        var wantedTerm = new Term(sfModel.StartDate, sfModel.EndDate);

        if (sfModel.Makes.Values.All(m => m == false))
        {
            var cars = _carService.GetAll();
            carModels = _mapper.Map<List<CarViewModel>>(carModels);
        }
        if (sfModel.Makes.Values.Contains(true))
        {
            var selectedMakes = sfModel.Makes.Where(m => m.Value == true).Select(m => m.Key);
            carModels = _carService.GetAll()
                .Where(c => selectedMakes.Contains(c.Make, StringComparer.CurrentCultureIgnoreCase)).ToList();
        }
        if (sfModel.ProductionYearFrom > 0 && sfModel.ProductionYearTo > 0)
        {
            carModels = carModels.Where(c => c.Year >= sfModel.ProductionYearFrom && c.Year <= sfModel.ProductionYearTo).ToList();
        }

        if (!string.IsNullOrEmpty(sfModel.Model))
        {
            carModels = carModels.Where(c => c.Make.Contains(sfModel.Model, StringComparison.CurrentCultureIgnoreCase) ||
                                   c.CarModelProp.Contains(sfModel.Model, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (sfModel.StartDate != null && sfModel.EndDate != null)
        {
            var availableCarIds = _rentalService
                .GetCarsAvailableInTerm(wantedTerm)
                .Select(c => c.Id);
            carModels = carModels.Where(c => availableCarIds.Contains(c.Id)).ToList();
        }

        return carModels;
    }
}
