using Newtonsoft.Json;

namespace CarRental.DAL.Models;
public sealed class PostalAddress
{
    [JsonProperty("country")]
    public string Country { get; set; } = "Polska";

    [JsonProperty("city")]
    public string City { get; set; } = string.Empty;

    [JsonProperty("zip_code")]
    public string ZipCode { get; set; } = string.Empty;

    [JsonProperty("street")]
    public string Street { get; set; } = string.Empty;

    [JsonProperty("buildong_number")]
    public string BuildingNo { get; set; } = string.Empty;

    [JsonProperty("apartment_number")]
    public string ApartmentNo { get; set; } = string.Empty;
}
