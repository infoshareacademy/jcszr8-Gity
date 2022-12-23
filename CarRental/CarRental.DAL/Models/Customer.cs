using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Models
{
    public sealed class Customer : Person
    {
        public int CustomerId;
        public Customer(int id, string firstName, string lastName, string emailAddress, string phoneNumber, string pesel) : base(id, firstName, lastName, emailAddress, phoneNumber, pesel)
        {
        }
    }
}
