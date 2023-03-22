using CarRental.DAL.Entities.BaseEntity;

namespace CarRental.DAL.Repositories;

public interface IRepository<T> where T : Entity
{
    List<T> GetAll();
    T Get(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
}
