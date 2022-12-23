using CarRental.DAL.Enums;
using CarRental.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Utilities
{
    public class CarsTSVFileReader : TSVFileReader
    {
        public static string TSV_FILE_NAME = "cars.tsv";

        public List<Car> cars = new();

        public override void ReadTsv()
        {
            using (var reader = new StreamReader(PATH_TO_TSV_FILES + TSV_FILE_NAME))
            {
                var headingLine = reader.ReadLine(); // Headings in the first line of the file
                if (headingLine != null)
                {
                    var headingColumns = headingLine.Split(SEPARATOR);

                    // Read each data line and add a dictionary to the list.
                    while (!reader.EndOfStream)
                    {
                        var dataLine = reader.ReadLine();
                        if (dataLine != null)
                        {
                            var dataColumns = dataLine.Split(SEPARATOR);

                            var item = new Dictionary<string, string>();
                            for (int i = 0; i < headingColumns.Length; i++)
                            {
                                item.Add(headingColumns[i], dataColumns[i]);
                            }
                            elements.Add(item);
                        }
                    }
                }
            }
        }

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
                    //Ac = carRecord["ac"] == "true" ? true : false,
                    Ac = bool.Parse(item["ac"].Trim()),  // TODO: check correctness
                    Transmission = item["transmission"].Trim(),
                    SeatsNo = int.Parse(item["seats"].Trim()),
                    LicencePlateNumber = item["licence_plate_number"].Trim(),
                    Doors = int.Parse(item["doors"].Trim()),
                    VIN = item["vin"].Trim(),
                    EngineParameters = new EngineParameters()
                    {
                        Type = EngineType.Parse<EngineType>(item["engine.type"].Trim()),
                        Torque = item["engine.torque"].Trim(),
                        Displacement = item["engine.displacement"].Trim(),
                        PowerInKiloWats = float.Parse(item["engine.power_kw"].Trim()),
                        PowerInKM = float.Parse(item["engine.power_km"].Trim()),
                    },
                    FuelConsumptionCity = float.Parse(item["fuel_consumption_city"].Trim()),
                    FuelConsumptionHighway = float.Parse(item["fuel_consumption_highway"].Trim()),
                    Segment = item["segment"].Trim(),
                    Airbags = int.Parse(item["airbags"].Trim()),
                    Addons = item["addons"].Split(',').ToList(),  // TODO: remove white spaces

                    //Images

                });
            }
        }
    }
}
