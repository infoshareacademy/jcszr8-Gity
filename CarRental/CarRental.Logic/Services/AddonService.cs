using System.Text;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;
public class AddonService : IAddonService
{
    //public void AddAddon(string addons)
    //{
    //    string addon = _availableAddons[index];
    //    this.Addons.Add(addon);
    //}

    //public void RemoveAddon(int index)
    //{
    //    try
    //    {
    //        this.Addons.RemoveAt(index);
    //    }
    //    catch (Exception)
    //    {

    //    }
    //}

    public List<string> GetAddonsAsList(string addons)
    {
        return addons.Split(';').ToList();
    }

    public string GetAddonsAsString(List<string> addons)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in addons)
        {
            sb.AppendJoin(';', item.ToString());
        }
        return sb.ToString();
    }


    //public List<CarModel> GetByAddons(string addon)
    //{
    //    List<CarModel> cars = new List<CarModel>();
    //    if (string.IsNullOrEmpty(addon))
    //    {
    //        cars = _mapper.Map<List<CarModel>>(_carRepository.GetAll());
    //    }
    //    else
    //    {
    //        foreach (var car in _carRepository.GetAll())
    //        {

    //            foreach (var item in car.Addons.Split(";"))
    //            {
    //                if (item.Contains(addon))
    //                {
    //                    //  cars.Add(car);  // TODO ?????? GetByAddons
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    return cars;
    //}

    //List<CarModel> GetByAddons(string addon);



}
