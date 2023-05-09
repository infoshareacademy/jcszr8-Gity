using CarRental.Common.Enums;
using Newtonsoft.Json;

namespace CarRental.DAL.HelperModels;

public class CustomerJson
{
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("email_address")]
    public string? EmailAddress { get; set; }

    [JsonProperty("pesel")]
    public string? Pesel { get; set; }

    [JsonProperty("gender")]
    public Gender Gender { get; set; }
}
