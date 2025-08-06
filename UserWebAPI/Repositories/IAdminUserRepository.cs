using UserWebAPI.DTOs;
using UserWebAPI.Models;

namespace UserWebAPI.Repositories
{
    public interface IAdminUserRepository
    {
        Task<User?> UpdateUserByNameAsync(string name, UpdateUserRequest request);
        Task LogActivityAsync(UserActivity activity);
    
    }

}
