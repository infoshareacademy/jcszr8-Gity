using AutoMapper;
using CarRental.Common;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;
public class CommonService : ICommonService
{
    private readonly ICarService _carService;

    private readonly IMapper _mapper;

    public CommonService(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    public List<CarViewModel> SearchList(SearchFieldsModel sfModel)
    {
        // TODO refactor SearchList
        var wantedTerm = new Term(sfModel.StartDate, sfModel.EndDate);

        List<CarViewModel> results = new List<CarViewModel>();
        results = _carService.FindCarsFromHome(results, sfModel);
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
