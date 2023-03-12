using CarRental.DAL.Models;

namespace CarRental.DAL.Repositories;

public interface IRepository<T> where T : EntityBase
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
