using Newtonsoft.Json;

namespace CarRental.DAL.Models;
public sealed class Rental
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("customer_id")]
    public int CustomerId { get; set; }

    [JsonProperty("car_id")]
    public int CarId { get; set; }

    [JsonProperty("begin_datetime")]
    public DateTime BeginDate { get; set; }

    [JsonProperty("end_datetime")]
    public DateTime EndDate { get; set; }

    [JsonProperty("total_cost")]
    [Display (Name = "Total Cost")]
    public decimal TotalCost { get; set; }
}
