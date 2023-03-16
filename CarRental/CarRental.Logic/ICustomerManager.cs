using CarRental.DAL.Models;

namespace CarRental.Logic;

public interface ICustomerManager
{
    List<Customer> GetAll();

    Customer GetById(int id);

    Customer Create(Customer customer);

    Customer Update(Customer customer);

    Customer DeleteById(int id);

    void Add(Customer customer);
}
