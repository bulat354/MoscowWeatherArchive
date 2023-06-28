using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistense
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<WeatherForecast> MoscowWeatherForecasts { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}