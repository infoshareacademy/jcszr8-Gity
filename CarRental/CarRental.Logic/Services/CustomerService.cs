using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.DAL.Repositories;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<CustomerModel> _customerRepository;
    private static int _idCounter;
    //private List<Customer> _customers = CarRentalData.Customers;

    public CustomerService(IRepository<CustomerModel> customerRepository)
    {
        _customerRepository = customerRepository;
        _idCounter = CarRentalData.Customers.Max(c => c.Id);  // TODO  _idCounter = CarRentalData.Customers.Max(c => c.Id);
    }

    public IEnumerable<CustomerModel> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public CustomerModel? Get(int customerId)
    {
        return _customerRepository.GetAll().FirstOrDefault(c => c.Id == customerId);
    }

    public void Create(CustomerModel customer)
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

        _customerRepository.Insert(new CustomerModel
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        });
    }

    public void Update(CustomerModel model)
    {
        _customerRepository.Update(model);
    }

    public void Delete(int customerId) {

        var customer = _customerRepository.Get(customerId);
        _customerRepository.Delete(customer);
    }  

    private int GetNextId() => ++_idCounter;  // TODO GenNextId()
}
