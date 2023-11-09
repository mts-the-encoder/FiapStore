namespace FiapStore.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}