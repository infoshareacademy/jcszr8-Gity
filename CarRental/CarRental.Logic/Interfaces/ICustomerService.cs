using CarRental.DAL.Models;

namespace CarRental.Logic.Interfaces;

public interface ICustomerService
{
    List<Customer> GetAll();

    Customer? GetById(int id);

    void Create(Customer customer);

    void Update(Customer customer);

    void Delete(int id);
}
