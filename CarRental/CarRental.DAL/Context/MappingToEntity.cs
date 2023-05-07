using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;

namespace CarRental.DAL.Context;

public class MappingToEntity : IMappingToEntity
{
    private readonly IMapper _mapper;
    public MappingToEntity(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<Car> MapFromCarJson(List<CarJson> carsFromJson)
    {
        return _mapper.Map<List<Car>>(carsFromJson);
    }
}

public interface IMappingToEntity
{

}
