using CarRental.DAL.Models;

namespace CarRental.DAL.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private static List<Customer> _customers { get; set; } = CarRentalData.Customers;

    public IEnumerable<Customer> GetAll()
    {
        return _customers;
    }

    public Customer GetById(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Customer entity)
    {
        _customers.Add(entity);
    }

    public void Update(Customer entity)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == entity.Id);

        customer.Id = entity.Id;
        customer.FirstName = entity.FirstName;
        customer.LastName = entity.LastName;
        customer.EmailAddress = entity.EmailAddress;
        customer.PhoneNumber = entity.PhoneNumber;
        customer.Pesel = entity.Pesel;
        customer.Gender = entity.Gender;
    }

    public void Delete(Customer entity)
    {
        _customers.Remove(entity);
    }
}
