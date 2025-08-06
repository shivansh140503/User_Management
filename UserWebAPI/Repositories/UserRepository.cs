using Microsoft.EntityFrameworkCore;
using UserWebAPI.Data;
using UserWebAPI.Models;
using UserWebAPI.DTOs;


namespace UserWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }


        public async Task LogActivityAsync(UserActivity activity)
        {
            await _context.UserActivity.AddAsync(activity);
            await _context.SaveChangesAsync();
        }


        public async Task<User> CreateAsync(User user)
        {
            user.UserID = Guid.NewGuid();
            await _context.Users.AddAsync(user);


            var activity = new UserActivity
            {
                ActivityID = Guid.NewGuid(),
                UserID = user.UserID,
                Activity = "User Created",
                Role = user.Role,
                Timestamp = DateTime.UtcNow
            };

            await _context.UsersActivity.AddAsync(activity);

            await _context.SaveChangesAsync();
            return user;
        }


    }
}
