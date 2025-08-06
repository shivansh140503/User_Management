using Microsoft.EntityFrameworkCore;
using UserWebAPI.Models;

namespace UserWebAPI.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserActivity> UserActivity => Set<UserActivity>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserActivity> UsersActivity => Set<UserActivity>();
    public DbSet<User> USERS { get; set; }
    public DbSet<UserActivity> USERSActivity { get; set; }

}
