using UserWebAPI.DTOs;
using UserWebAPI.Models;

namespace UserWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User user);
        Task LogActivityAsync(UserActivity activity);
        Task<bool> EmailExistsAsync(string email);



    }
}
