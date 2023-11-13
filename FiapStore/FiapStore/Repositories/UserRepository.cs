using FiapStore.Entities;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repositories;

public class UserRepository : EFRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }
    
    public User GetWithOrders(int id)
    {
        return _context.Users.Include(x => x.Orders).Where(x => x.Id == id)
            .ToList().Select(order =>
            {
                order.Orders = order.Orders.Select(order => new Order(order)).ToList();
                return order;
            }).FirstOrDefault();
    }

}