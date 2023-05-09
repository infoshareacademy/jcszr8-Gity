using CarRental.DAL.Entities.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.DAL.Entities;

public class Rental : Entity
{
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? TotalCost { get; set; }
    public Customer Customer { get; set; }
    public Car Car { get; set; }
}
