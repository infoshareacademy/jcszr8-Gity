namespace CarRental.Web.Models;

public class CarListModel
{
    public int Id { get; set; }

    public string? CarModel { get; set; }

    public string? Make { get; set; }

    public int? Year { get; set; }

    public string? LicencePlateNumber { get; set; }
}
