using Newtonsoft.Json;

namespace CarRental.DAL.Models;
public sealed class Customer : Person
{
    [JsonProperty("id")]

    public int Id;
    public Customer(string firstName, string lastName, string phoneNumber)
        : base(firstName, lastName, phoneNumber)
    {
    }
}
