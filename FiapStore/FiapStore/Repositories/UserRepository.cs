using FiapStore.Entities;
using FiapStore.Interface;

namespace FiapStore.Repositories;

public class UserRepository : DapperRepository<User>, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration) { }
    public override IList<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public override User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public override void Create(User entity)
    {
        throw new NotImplementedException();
    }

    public override void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(int id)
    {
        throw new NotImplementedException();
    }
}