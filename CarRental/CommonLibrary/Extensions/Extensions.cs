using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Extensions;

public static class Extensions
{
    public static string DefaultDateFormat(this DateTime dateTime)
    {
        return Convert.ToDateTime(dateTime).ToString("dd-MM-yyyy hh:mm");
    }
}
