using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic
{
    public interface ICustomerManager
    {
        List<Customer> GetAll();

        Customer GetById(int id);

        Customer Create(Customer customer);

        Customer Update(Customer customer);

        Customer DeleteById(int id);

        void Add(Customer customer);
    }
}
