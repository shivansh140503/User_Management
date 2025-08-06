using Microsoft.EntityFrameworkCore;
using UserWebAPI.Data;
using UserWebAPI.Models;

namespace UserWebAPI.Repositories
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly AppDbContext _context;

        public AdminUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> UpdateUserByNameAsync(string name, UpdateUserRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.FNAME == request.Name);

            if (user == null) return null;

            user.Email = request.Email;
            user.Password = request.Password;
            user.Role = request.Role;

            await _context.SaveChangesAsync();
            return user;
        }
        public async Task LogActivityAsync(UserActivity activity)
        {
            await _context.UserActivity.AddAsync(activity); // ✅ Use correct DbSet
            await _context.SaveChangesAsync();
        }
    }
}
