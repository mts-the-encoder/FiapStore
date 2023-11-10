using Dapper;
using FiapStore.Entities;
using FiapStore.Interface;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace FiapStore.Repositories;

public class UserRepository : DapperRepository<User>, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration) { }
    public override IList<User> GetAll()
    {
        using var dbConnection = new SqlConnection(ConnectionString);
        const string query = "SELECT [Id], [Name] FROM [FiapStore].[dbo].[User] ";
        return dbConnection.Query<User>(query).ToList();
    }

    public override User GetById(int id)
    {
        using var dbConnection = new SqlConnection(ConnectionString);
        const string query = "SELECT [Id], [Name] FROM [FiapStore].[dbo].[User] WHERE Id = @Id";
        return dbConnection.Query<User>(query, new { Id = id }).FirstOrDefault();
    }

    public override void Create(User entity)
    {
        using var dbConnection = new SqlConnection(ConnectionString);
        var query = "INSERT INTO [dbo].[User] ([Name]) VALUES (@Name)";
        dbConnection.Execute(query, entity);
    }

    public override void Update(User entity)
    {
        using var dbConnection = new SqlConnection(ConnectionString);
        var query = "UPDATE [dbo].[User] SET [Name] = @Name WHERE Id = @Id";
        dbConnection.Query(query, entity);
    }

    public override void Delete(int id)
    {
        using var dbConnection = new SqlConnection(ConnectionString);
        const string query = "DELETE FROM [FiapStore].[dbo].[User] WHERE Id = @Id";
        dbConnection.Execute(query, new { Id = id });
    }

    public User GetWithOrders(int id)
    {
        using var dbConnection = new SqlConnection(ConnectionString);
        var query = "SELECT u.*, o.* FROM[FiapStore].[dbo].[User] u LEFT JOIN [FiapStore].[dbo].[Order] o ON u.Id = o.UserId";
        var result = new Dictionary<int, User>();
        var param = new { Id = id };
        
        dbConnection.Query<User, Order, User>(query, (user, order) =>
        {
            if (!result.TryGetValue(user.Id, out var existingUser))
            {
                existingUser = user;
                existingUser.Orders = new List<Order>();
                result.Add(user.Id, existingUser);
            }

            if (order != null) existingUser.Orders.Add(order);

            return existingUser;
        }, param, splitOn: "Id");

        return result.Values.FirstOrDefault();
    }
}