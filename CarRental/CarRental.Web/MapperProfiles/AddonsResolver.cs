using AutoMapper;
using CarRental.DAL.Models;

namespace CarRental.Logic.Test;

public class AddonsResolver : IValueResolver<CarModel, Car, string>
{
    public string Resolve(CarModel source, Car destination, string destMember, ResolutionContext context)
    {
        return string.Join(",", source.Addons);
    }
}
