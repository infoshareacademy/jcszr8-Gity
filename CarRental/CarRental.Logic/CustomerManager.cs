using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic;

public class CustomerManager
{
    private static int _idCounter = CarRentalData.Customers
        .Max(c => c.Id);
    private static List<CustomerModel> _customers = CarRentalData.Customers;

    public static CustomerModel Create(string firstName, string lastName, string phoneNumber)
    {
        int id = GetNextId();
        var customer = new CustomerModel(id, firstName, lastName, phoneNumber);
        _customers.Add(customer);
        return customer;
    }

    public static List<CustomerModel> GetAll()
    {
        return _customers;
    }

    public static CustomerModel GetById(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public static void Update(CustomerModel customer)
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

    public CustomerModel Create(CustomerModel customer)
    {
        throw new NotImplementedException();
    }

    public void Add(CustomerModel customer)
    {
        throw new NotImplementedException();
    }
}
