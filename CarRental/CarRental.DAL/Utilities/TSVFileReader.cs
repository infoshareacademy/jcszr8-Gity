using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Utilities
{
    public abstract class TSVFileReader
    {
        protected const char SEPARATOR = '\t';

        protected const string PATH_TO_TSV_FILES = @"..\..\..\..\CarRental.DAL\Data\AuxiliaryData\";

        // Each dictionary represents a row, and dictionary key represents a column name
        public List<Dictionary<string, string>> elements = new();
        public void ReadTsv(string tsvFileName)
        {
            using (var reader = new StreamReader(PATH_TO_TSV_FILES + tsvFileName))
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

        public abstract void LoadItems();
    }
}
