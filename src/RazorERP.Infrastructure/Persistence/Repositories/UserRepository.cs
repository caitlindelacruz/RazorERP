using RazorERP.Application.Interfaces;
using RazorERP.Domain.Entities;
using System.Data;
using Dapper;

namespace RazorERP.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(SqlConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
        }

        public async Task AddAsync(User user)
        {
            const string sql = "INSERT INTO Users (Name, Email, PasswordHash, Role) VALUES (@Name, @Email, @PasswordHash, @Role)";
            await _connection.ExecuteAsync(sql, user);
        }

        public async Task<User?> GetAsync(int id)
        {
            const string sql = "SELECT * FROM Users WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            const string sql = "SELECT * FROM Users WHERE Email = @email";
            return await _connection.QuerySingleOrDefaultAsync<User>(sql, new { Email = email });
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            const string sql = "SELECT * FROM Users";
            var users = await _connection.QueryAsync<User>(sql);
            return users.ToList();
        }

        public async Task<List<User>> GetNonAdminUsersAsync()
        {
            const string sql = "SELECT * FROM Users WHERE Role != 'Admin'";
            var users = await _connection.QueryAsync<User>(sql);
            return users.ToList();
        }
        public async Task UpdateAsync(User user)
        {
            const string sql = "UPDATE Users SET Name = @Name, Role = @Role WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, user);
        }
        public async Task DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Users WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
