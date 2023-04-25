using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;

public class RentalViewModel
{
    public int Id { get; set; 
    [Display(Name = "Customer ID")]
    public int CustomerId { get; set; }
    [Display(Name = "Car ID")]
    public int CarId { get; set; }
    [Display(Name = "Begin Date")]
    public DateTime BeginDate { get; set; }
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set;
    [Display(Name = "Total Cost")]
    public decimal? TotalCost { get; set; }

    [Display(Name = "Customer Name")]
    public string? CustomerName { get; set; }

    [Display(Name = "Car License Plate")]
    public string? CarLicencePlate { get; set; }


    //private DateTime _beginDate;
    //private DateTime _endDate;
    //private decimal _totaCost;


    //public DateTime BeginDate
    //{
    //    get
    //    {
    //        return _beginDate;
    //    }
    //    set
    //    {
    //        _beginDate = value < _endDate ? value : _endDate;
    //    }
    //}

    //public DateTime EndDate
    //{
    //    get
    //    {
    //        return _endDate;
    //    }
    //    set
    //    {
    //        _endDate = value > _beginDate ? value : _beginDate;
    //    }
    //}

    //public decimal? TotalCost
    //{
    //    get
    //    {
    //        return _totaCost;
    //    }
    //    set
    //    {
    //        TotalCost = value > 0 ? value : 0;
    //    }
    //}
}
