using FiapStore.Dtos;

namespace FiapStore.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }

    public User()
    {
    }

    public User(CreateUserDto user)
    {
        Name = user.Name;
    }

    public User(UpdateUserDto user)
    {
        Id = user.Id;
        Name = user.Name;
    }
}