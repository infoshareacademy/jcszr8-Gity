using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Models;
public sealed class Rental : EntityBase
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("customer_id")]
    [Display (Name = "Customer Id")]
    public int CustomerId { get; set; }

    [JsonProperty("car_id")]
    [Display (Name = "Car Id")]
    public int CarId { get; set; }

    [JsonProperty("begin_datetime")]
    [Display (Name = "Start of Rental")]
    public DateTime BeginDate { get; set; }

    [JsonProperty("end_datetime")]
    [Display (Name = "End of Rental")]
    public DateTime EndDate { get; set; }

    [JsonProperty("total_cost")]
    [Display (Name = "Total Cost")]
    public decimal? TotalCost { get; set; }
}
