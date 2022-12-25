using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Models
{
    public sealed class Customer : Person
    {
        [JsonProperty("id")]

        public int Id;
        public Customer(string firstName, string lastName, string phoneNumber)
            : base(firstName, lastName, phoneNumber)
        {
        }
    }
}
