using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DAL.Context;
using CarRental.DAL.Models;

namespace CarRental.Logic.Test
{
    public class AddonsResolver
    {
        public string Resolve(Car source, CarDb destination, string destMember, ApplicationContext context)
        {
            return string.Join(",", source.Addons);
        }
    }
}
