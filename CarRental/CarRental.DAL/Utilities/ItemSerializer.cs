using Newtonsoft.Json;

namespace CarRental.DAL.Utilities;
public static class ItemSerializer<T>
{
    private const string PATH_TO_JSON_FILES = @"..\..\..\..\CarRental.DAL\Data\AuxiliaryData\";

    public static string Serialize(List<T> objects)
    {
        return JsonConvert.SerializeObject(objects);
    }

    public static List<T> Deserialize(string itemsSerialized)
    {
        return JsonConvert.DeserializeObject<List<T>>(itemsSerialized) ?? new List<T>();
    }

}
