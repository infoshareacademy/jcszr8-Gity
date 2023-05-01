using AutoMapper;
using CarRental.Common;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;
public class CommonService : ICommonService
{
    private readonly ICarService _carService;
    private readonly ICustomerService _customerService;
    private readonly IRentalService _rentalService;

    private readonly IMapper _mapper;

    public CommonService(ICarService carService, ICustomerService customerService,
        IRentalService rentalService, IMapper mapper)
    {
        _carService = carService;
        _customerService = customerService;

        _mapper = mapper;
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
        return results;
    }

    public List<CarViewModel> FilterList(SearchFieldsModel sfModel)
    {
        // TODO refactor FindCars()
        List<CarViewModel> carModels = _carService.GetAll().ToList();
        carModels = _carService.FindCars(carModels, sfModel);

        return carModels;
    }
}
