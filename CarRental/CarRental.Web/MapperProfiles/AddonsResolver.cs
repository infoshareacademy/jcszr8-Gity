using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.DAL.Context;
using CarRental.DAL.Models;

namespace CarRental.Logic.Test
{
    public class AddonsResolver : IValueResolver<Car, CarDb, string>
    {
        public string Resolve(Car source, CarDb destination, string destMember, ResolutionContext context)
        {
            return string.Join(",", source.Addons);
        }
    }
}
