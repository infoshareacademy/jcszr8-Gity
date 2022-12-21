using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Utilities
{
    public class TSVToJSONDataConverter
    {
        /*
         *  This is helper class for converting TSV formated data into JSON formated data
         * 
         */
        private static List<Dictionary<string, string>> ReadTsv(string filePath)
        {
            const char SEPARATOR = '\t';
            // Each dictionary represents a row, and dictionary key represents a column name
            var records = new List<Dictionary<string, string>>();

            using (var reader = new StreamReader(filePath))
            {
                // First line contains headings of data
                var headingLine = reader.ReadLine();
                var headingColumns = headingLine.Split(SEPARATOR);

                // Read each data line and add a dictionary to the list.
                while (!reader.EndOfStream)
                {
                    var dataLine = reader.ReadLine();
                    var dataColumns = dataLine.Split(SEPARATOR);

                    var record = new Dictionary<string, string>();
                    for (int i = 0; i < headingColumns.Length; i++)
                    {
                        record.Add(headingColumns[i], dataColumns[i]);
                    }
                    records.Add(record);
                }
            }

            return records;
        }

        public static List<Car> GetCarsFromTSVFile(string filePath)
        {
            List<Dictionary<string, string>> carRecords = ReadTsv(filePath);

            List<Car> cars = new();

            foreach(var carRecord in carRecords)
            {
                cars.Add(new Car()
                {
                    Make = carRecord["make"].Trim(),
                    Model = carRecord["model"].Trim(),
                    Color = carRecord["color"].Trim(),
                    //Ac = carRecord["ac"] == "true" ? true : false,
                    Ac = bool.Parse(carRecord["ac"]),
                    Transmission = carRecord["transmission"].Trim(),
                    SeatsNo = int.Parse(carRecord["seats"]),
                    LicencePlateNumber = carRecord["licence_plate_number"].Trim(),
                    Doors = int.Parse(carRecord["doors"]),
                    VIN = carRecord["VIN"].Trim(),
                    EngineType = carRecord["engine_type"].Trim(),
                    Addons = carRecord["addons"].Split(',').ToList()
                });
            }

            return cars;
        }

        public static void WriteSerializedCarsToJSONFile(List<Car> cars, string filePath)
        {
            // serialize list of cars to file


            string carsSerialized = JsonConvert.SerializeObject(cars);
            File.WriteAllText(filePath, carsSerialized);
        }

        public static void MigrateCarsDataFromTSVFileToJsonFile()
        {
            var cars = GetCarsFromTSVFile(@"..\..\..\..\CarRental.DAL\Data\DataTSV\cars.tsv");
            WriteSerializedCarsToJSONFile(cars, @"..\..\..\..\CarRental.DAL\Data\carsSerialized.json");
        }
    }
}
