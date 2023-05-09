using CarRental.DAL.Entities.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.DAL.Entities;

public class Rental : Entity
{
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? TotalCost { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    [ForeignKey("Car")]
    public int CarId { get; set; }
    public virtual Car Car { get; set; }
}
