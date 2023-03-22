using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarRental.DAL.Entities;

public class Rental
{
    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal? TotalCost { get; set; }
}
