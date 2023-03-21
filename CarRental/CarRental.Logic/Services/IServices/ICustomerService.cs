using CarRental.DAL.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();

    Customer? Get(int id);

    void Create(Customer customer);

    void Create(string firstName, string lastName, string phoneNumber);

    void Update(Customer customer);

    void Delete(int id);
}
