using RazorERP.Domain.Entities;

namespace RazorERP.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);

        Task AddAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetNonAdminUsersAsync();

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}
