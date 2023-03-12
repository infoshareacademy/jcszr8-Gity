using CarRental.DAL.Models;
using System.ComponentModel;

namespace CarRental.Web.Models;

public class RentalListModel
{
    [DisplayName("Rental Id.")]
    public int Id { get; set; }

    [DisplayName("Customer Id.")]
    public int CustomerId { get; set; }

    [DisplayName("Car Id.")]
    public int CarId { get; set; }

    [DisplayName("Start of Rental")]
    public DateTime BeginDate { get; set; }

    [DisplayName("End of Rental")]
    public DateTime EndDate { get; set; }

    [DisplayName("Total Cost")]
    public decimal TotalCost { get; set; }

    public RentalListModel FillModel(Rental baseModel)
    {
        this.Id = baseModel.Id;
        this.CustomerId = baseModel.CustomerId;
        this.CarId = baseModel.CarId;
        this.BeginDate = baseModel.BeginDate;
        this.EndDate = baseModel.EndDate;
        this.TotalCost = baseModel.TotalCost;

        return this;
    }
}
