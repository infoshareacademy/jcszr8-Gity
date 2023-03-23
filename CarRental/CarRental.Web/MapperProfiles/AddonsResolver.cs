using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.Test;

public class AddonsResolver : IValueResolver<CarModel, Car, string>
{
    public string Resolve(CarModel source, Car destination, string destMember, ResolutionContext context)
    {
        return string.Join(",", source.Addons);
    }
}
