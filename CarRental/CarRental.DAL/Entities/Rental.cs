using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Entities;

public class Rental : Entity
{
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? TotalCost { get; set; }
}
