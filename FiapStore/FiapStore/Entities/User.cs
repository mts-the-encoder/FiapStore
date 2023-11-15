using FiapStore.Dtos;
using FiapStore.Enums;

namespace FiapStore.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public PermissionType Permission { get; set; }
    public ICollection<Order> Orders { get; set; }

    public User()
    {
    }

    public User(CreateUserDto user)
    {
        Name = user.Name;
        Username = user.Username;
        Password = user.Password;
        Permission = user.Permission;
    }

    public User(UpdateUserDto user)
    {
        Id = user.Id;
        Name = user.Name;
    }
}