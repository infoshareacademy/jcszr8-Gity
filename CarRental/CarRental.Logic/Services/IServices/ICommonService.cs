using CarRental.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services.IServices;
public interface ICommonService
{
    List<CarViewModel> FilterList(SearchFieldsModel sfModel);
    List<CarViewModel> SearchList(SearchFieldsModel sfModel);
}
