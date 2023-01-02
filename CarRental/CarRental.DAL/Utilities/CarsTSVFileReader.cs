using CarRental.DAL.Enums;
using CarRental.DAL.Models;

namespace CarRental.DAL.Utilities;
public sealed class CarsTSVFileReader : TSVFileReader
{
    public static string CARS_TSV_FILE_NAME = "cars.tsv";

    public List<Car> cars = new();

    public override void LoadItems()
    {
        foreach (var item in this.elements)
        {
            this.cars.Add(new Car()
            {
                Id = int.Parse(item["id"]),
                Make = item["make"].Trim(),
                Model = item["model"].Trim(),
                Year = int.Parse(item["year"].Trim()),
                Color = item["color"].Trim(),
                Ac = bool.Parse(item["ac"].Trim()),  // TODO: check correctness
                Transmission = item["transmission"].Trim(),
                SeatsNo = int.Parse(item["seats"].Trim()),
                LicencePlateNumber = item["licence_plate_number"].Trim(),
                Doors = int.Parse(item["doors"].Trim()),
                VIN = item["vin"].Trim(),
                EngineParameters = new EngineParameters()
                {
                    Type = EngineType.Parse<EngineType>(item["engine.type"].Trim()),
                    Displacement = item["engine.displacement"].Trim(),
                    PowerInKiloWats = float.Parse(item["engine.power_kw"].Trim()),
                },
                FuelConsumption = item["fuel_consumption"].Trim(),
                Airbags = int.Parse(item["airbags"].Trim()),
                Kilometrage = int.Parse(item["kilometrage"].Trim()),
                Addons = item["addons"].Split(',').ToList(),  // TODO: remove white spaces
            });
        }
    }
}
