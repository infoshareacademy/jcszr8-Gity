namespace CarRental.Logic.Services;
public class AddonService
{
    //public void AddAddon(int index)
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

    //public string AddonsToString()
    //{
    //    StringBuilder sb = new StringBuilder();
    //    foreach (string addon in Addons)
    //    {
    //        sb.Append(addon);
    //        sb.Append(", ");
    //    }
    //    return sb.ToString();
    //}

    //public string GetAddonsToString()
    //{
    //    StringBuilder sb = new StringBuilder();

    //    foreach (var item in Addons)
    //    {
    //        sb.AppendJoin(';', item.ToString());
    //        sb.Append('\u002C');
    //    }
    //    return sb.ToString();
    //}

    //public string GetAddonsToString()
    //{
    //    StringBuilder sb = new StringBuilder();

    //    foreach (var item in Addons)
    //    {
    //        sb.AppendJoin(';', item.ToString());
    //        sb.Append('\u002C');
    //    }
    //    return sb.ToString();
    //}

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
