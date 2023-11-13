using FiapStore.Entities;
using FiapStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repositories;

public class EFRepository<T> : IRepository<T> where T : Entity
{
    protected readonly ApplicationDbContext _context;
    protected DbSet<T> _dbSet;
    public EFRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IList<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.FirstOrDefault(x => x.Id == id);
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.FirstOrDefault(x => x.Id == id);
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}