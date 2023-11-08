using FiapStore.Entities;

namespace FiapStore.Interface;

public interface IUserRepository
{
    IList<User> GetAll();
    User GetById(int id);
    void Create(User user);
    void Update(User user);
    void Delete(int id);
}