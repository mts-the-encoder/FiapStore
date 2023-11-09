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
}