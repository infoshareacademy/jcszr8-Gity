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
    public List<CarModel> SearchList(SearchCarModel searchModel)
    {
        List<CarModel> results = new List<CarModel>();
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

    public List<CarModel> FilterList(SearchCarModel searchDto)
    {
        List<CarModel> carModels = new();

        if (searchDto.Makes.Values.All(m => m == false))
        {
            var cars = _carService.GetAll();
            carModels = _mapper.Map<List<CarModel>>(carModels);
        }
        if (searchDto.Makes.Values.Contains(true))
        {
            var selectedMakes = searchDto.Makes.Where(m => m.Value == true).Select(m => m.Key);
            carModels = _carService.GetAll()
                .Where(c => selectedMakes.Contains(c.Make, StringComparer.CurrentCultureIgnoreCase)).ToList();
        }
        if (searchDto.ProductionYearFrom > 0 && searchDto.ProductionYearTo > 0)
        {
            carModels = carModels.Where(c => c.Year >= searchDto.ProductionYearFrom && c.Year <= searchDto.ProductionYearTo).ToList();
        }

        if (!string.IsNullOrEmpty(searchDto.Model))
        {
            carModels = carModels.Where(c => c.Make.Contains(searchDto.Model, StringComparison.CurrentCultureIgnoreCase) ||
                                   c.CarModelProp.Contains(searchDto.Model, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (searchDto.StartDate != null && searchDto.EndDate != null)
        {
            var availableCarIds = _rentalService.GetAvailableCarIds(searchDto.StartDate, searchDto.EndDate);
            carModels = carModels.Where(c => availableCarIds.Contains(c.Id)).ToList();
        }

        return carModels;
    }
}
