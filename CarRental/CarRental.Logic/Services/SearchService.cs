using AutoMapper;
using CarRental.DAL;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class SearchService : ISearchService
{
    private readonly ICarService _carService;
    private readonly IRentalService _rentalService;
    private readonly IMapper _mapper;
    public SearchService(ICarService carService, IRentalService rentalService, IMapper mapper)
    {
        _carService = carService;
        _rentalService = rentalService;
        _mapper = mapper;
    }
    public List<CarViewModel> SearchList(SearchFieldsModel searchModel)
    {
        List<CarViewModel> results = new List<CarViewModel>();
        var cars = _carService.GetByName(searchModel.ModelAndMake);

        if (searchModel.ProductionYearTo > 0 && searchModel.ProductionYearTo >= searchModel.ProductionYearFrom)
        {
            cars = cars.Where(c => c.Year >= searchModel.ProductionYearFrom && c.Year <= searchModel.ProductionYearTo).ToList();
        }
        IEnumerable<int> carIds = _rentalService.GetAvailableCarIds(searchModel.StartDate, searchModel.EndDate);
        foreach (var item in cars)
        {
            if (carIds.Any(x => x == item.Id))
            {
                results.Add(item);
            }
        }
        return results;
    }

    public List<CarViewModel> FilterList(SearchFieldsModel searchFields)
    {
        List<CarViewModel> carModels = _carService.GetAll().ToList();

        if (searchFields.Makes.Values.All(m => m == false))
        {
            var cars = _carService.GetAll();
            carModels = _mapper.Map<List<CarViewModel>>(carModels);
        }
        if (searchFields.Makes.Values.Contains(true))
        {
            var selectedMakes = searchFields.Makes.Where(m => m.Value == true).Select(m => m.Key);
            carModels = _carService.GetAll()
                .Where(c => selectedMakes.Contains(c.Make, StringComparer.CurrentCultureIgnoreCase)).ToList();
        }
        if (searchFields.ProductionYearFrom > 0 && searchFields.ProductionYearTo > 0)
        {
            carModels = carModels.Where(c => c.Year >= searchFields.ProductionYearFrom && c.Year <= searchFields.ProductionYearTo).ToList();
        }

        if (!string.IsNullOrEmpty(searchFields.Model))
        {
            carModels = carModels.Where(c => c.Make.Contains(searchFields.Model, StringComparison.CurrentCultureIgnoreCase) ||
                                   c.CarModelProp.Contains(searchFields.Model, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (searchFields.StartDate != null && searchFields.EndDate != null)
        {
            var availableCarIds = _rentalService.GetAvailableCarIds(searchFields.StartDate, searchFields.EndDate);
            carModels = carModels.Where(c => availableCarIds.Contains(c.Id)).ToList();
        }

        return carModels;
    }
}
