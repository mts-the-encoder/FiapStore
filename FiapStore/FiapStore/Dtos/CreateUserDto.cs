using FiapStore.Enums;

namespace FiapStore.Dtos;

public class CreateUserDto
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public PermissionType Permission { get; set; }
}