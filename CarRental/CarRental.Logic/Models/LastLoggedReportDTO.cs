using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Models;
public class LastLoggedReportDTO
{
    public int UserId { get; set; }
    public DateTime LastLogged { get; set; }
    public int LoginCount { get; set; }
}
