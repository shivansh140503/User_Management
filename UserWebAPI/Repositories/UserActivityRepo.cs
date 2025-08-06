using Microsoft.EntityFrameworkCore;
using UserWebAPI.Data;
using UserWebAPI.Models;
using UserWebAPI.DTOs;
using UserWebAPI.Repositories;

namespace UserWebAPI.Repository
{
    public class UserActivityRepo : IUserActivityRepository
    {
        private readonly AppDbContext _context;

        public UserActivityRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserActivity>> GetAllActivitiesAsync()
        {
            return await _context.UserActivity.ToListAsync();
        }

        public async Task<IEnumerable<AdminActivityDto>> GetAdminActivityLogAsync()
        {
            var activityLog = await (
                from ua in _context.UserActivity
                join u in _context.Users on ua.UserID equals u.UserID
                select new AdminActivityDto
                {
                    ActivityID = ua.ActivityID,
                    UserID = u.UserID,
                    Name = u.FNAME,        // or u.Name if that’s the actual column
                    Role = u.Role,
                    Activity = ua.Activity,
                    Timestamp = ua.Timestamp
                }
            ).ToListAsync();

            return activityLog;
        }

    }
}
