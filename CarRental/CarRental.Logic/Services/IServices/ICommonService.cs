using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface ICommonService
{
    List<CarViewModel> FilterList(SearchFieldsModel sfModel);
}
