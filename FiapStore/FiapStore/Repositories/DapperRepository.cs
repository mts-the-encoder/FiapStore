using FiapStore.Entities;
using FiapStore.Interfaces;

namespace FiapStore.Repositories;


public abstract class DapperRepository<T> : IRepository<T> where T : Entity
{
    private readonly string _connectionString;
    protected string ConnectionString => _connectionString;

    public DapperRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
    }

    public abstract IList<T> GetAll();
    public abstract T GetById(int id);
    public abstract void Create(T entity);
    public abstract void Update(T entity);
    public abstract void Delete(int id);
}