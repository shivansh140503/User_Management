using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UserWebAPI.Data
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "UserWebAPI"));
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
