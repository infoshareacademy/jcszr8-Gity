using AutoMapper;
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
    public List<CarViewModel> SearchList(SearchFieldsModel sfm)
    {
        throw new NotImplementedException();
    }

    public List<CarViewModel> FilterList(SearchFieldsModel searchFields)
    {
        throw new NotSupportedException();
    }
}
