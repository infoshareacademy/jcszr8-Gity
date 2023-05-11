using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Entities;

public class Rental : Entity
{
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? TotalCost { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public Car Car { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}
