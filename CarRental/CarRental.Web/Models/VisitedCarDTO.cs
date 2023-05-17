namespace CarRental.Web.Models;

public class VisitedCarDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime DateWhenClicked { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicencePlate { get; set; }
}
