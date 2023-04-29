using CarRental.DAL.Context;
using CarRental.DAL.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRental.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    //public List<T> GetAll()
    //{
    //    // TODO AsAsyncEnumerable()
    //    return this._entities.AsEnumerable().ToList();
    //}

    public List<T> GetAll(Expression<Func<T, object>>? include = null)
    {
        // TODO AsAsyncEnumerable()
        if (include == null)
        {
            return _entities.ToList();
        }
        //return this._entities.AsEnumerable().ToList();
        return _entities.Include(include).ToList();
    }

    public T Get(int id)
    {
        return this._entities.SingleOrDefault(e => e.Id == id)!;
    }

    public void Insert(T entity)
    {
        if (entity is null)
        {
            return; // or throw exception - incorrect usage
        }
        this._entities.Add(entity);
        this._context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity is null)
        {
            return;
        }
        this._entities.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        //_context.Remove(id);
        var entity = _entities.SingleOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _entities.Remove(entity);
        }
        _context.SaveChanges();
    }
}
