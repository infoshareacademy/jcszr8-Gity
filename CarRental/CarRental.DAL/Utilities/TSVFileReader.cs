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

        protected const string PATH_TO_TSV_FILES = @"..\..\..\..\CarRental.DAL\Data\DataTSV\";

        // Each dictionary represents a row, and dictionary key represents a column name
        public List<Dictionary<string, string>> elements = new();
        public abstract void ReadTsv();

        public abstract void LoadItems();
    }
}
