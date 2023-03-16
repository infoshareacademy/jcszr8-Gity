using Newtonsoft.Json;

namespace CarRental.DAL.Utilities;
public static class ItemSerializer<T>
{
    public static string Serialize(List<T> objects)
    {
        return JsonConvert.SerializeObject(objects);
    }

    public static List<T> Deserialize(string itemsSerialized)
    {
        return JsonConvert.DeserializeObject<List<T>>(itemsSerialized) ?? new List<T>();
    }
}
