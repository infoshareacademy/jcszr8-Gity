using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services
{
    public interface ISearchService
    {
        List<Car> SearchList(SearchViewModelDto search);
        List<Car> FilterList(SearchViewModelDto searchDto);
    }
}
