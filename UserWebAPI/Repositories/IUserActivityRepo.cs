using UserWebAPI.DTOs;
using UserWebAPI.Models;

namespace UserWebAPI.Repositories
{
    public interface IUserActivityRepository
    {
        Task<IEnumerable<AdminActivityDto>> GetAdminActivityLogAsync();
        //Task LogActivityAsync(UserActivity activity); // only if you need it
    }
}
