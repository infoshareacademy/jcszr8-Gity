using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public abstract class Person
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PostalAddress? PostalAddress { get; set; }

        public Person(int id, string firstName, string lastName, string emailAddress, string phoneNumber, string pesel)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Pesel = pesel;
        }

        public override string ToString()
        {
            return $"{this.GetType()}: {FirstName} {LastName} (id:{Id})";
        }
    }
}
