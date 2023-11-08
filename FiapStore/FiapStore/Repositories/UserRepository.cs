using FiapStore.Entities;
using FiapStore.Interface;

namespace FiapStore.Repositories;

public class UserRepository : IUserRepository
{
    private IList<User> _users = new List<User>();

    public IList<User> GetAll()
    {
        return _users;
    }

    public User GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public void Create(User user)
    {
        _users.Add(user);
    }

    public void Update(User user)
    {
        var userUpdated = GetById(user.Id);

        if (userUpdated != null) userUpdated.Name = user.Name;
    }

    public void Delete(int id)
    {
        _users.Remove(GetById(id));
    }
}