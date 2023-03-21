using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.DAL.Repositories;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private static int _idCounter;
    //private List<Customer> _customers = CarRentalData.Customers;

    public CustomerService(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
        _idCounter = CarRentalData.Customers.Max(c => c.Id);  // TODO  _idCounter = CarRentalData.Customers.Max(c => c.Id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public Customer? Get(int customerId)
    {
        return _customerRepository.GetAll().FirstOrDefault(c => c.Id == customerId);
    }

    public void Create(Customer customer)
    {
        customer.Id = GetNextId();
        _customerRepository.Insert(customer);
    }

    public void Create(string firstName, string lastName, string phoneNumber)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) 
            || string.IsNullOrEmpty(phoneNumber))
        {
            return;
        }

        _customerRepository.Insert(new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        });
    }

    public void Update(Customer model)
    {
        _customerRepository.Update(model);
    }

    public void Delete(int customerId) {

        var customer = _customerRepository.Get(customerId);
        _customerRepository.Delete(customer);
    }  

    private int GetNextId() => ++_idCounter;  // TODO GenNextId()
}
