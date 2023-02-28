using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICustomerService
{
    List<Customer> GetAll();

    Customer? GetById(int customerId);

    void Create(Customer customer);
}
