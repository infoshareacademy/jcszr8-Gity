using CarRental.DAL;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic;

public class CustomerManager
{
    private static int _idCounter = CarRentalData.Customers
        .Max(c => c.Id);
    private static List<Customer> _customers = CarRentalData.Customers;

    public static Customer Create(string firstName, string lastName, string phoneNumber)
    {
        int id = GetNextId();
        var customer = new Customer(id, firstName, lastName, phoneNumber);
        _customers.Add(customer);
        return customer;
    }

    public static List<Customer> GetAll()
    {
        return _customers;
    }

    public static Customer GetById(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public static void Update(Customer customer)
    {
        //TODO
    }

    public static void DeleteById(int id)
    {
        //TODO
    }

    private static int GetNextId()
    {
        return ++_idCounter;
    }

    public static string ToTableString()
    {
        //TODO ToTableString()
        throw new NotImplementedException();
    }

    public Customer Create(Customer customer)
    {
        throw new NotImplementedException();
    }

    public void Add(Customer customer)
    {
        throw new NotImplementedException();
    }
}
