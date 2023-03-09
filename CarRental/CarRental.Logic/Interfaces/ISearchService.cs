using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Interfaces
{
    public interface ISearchService
    {
        List<Car> SearchList(SearchViewModelDto search);
    }
}
