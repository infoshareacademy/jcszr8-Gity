using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICustomerService
{
    List<Customer> GetAll();

    Customer? GetById(int id);

    void Create(Customer customer);

    void Delete(int id);
}
