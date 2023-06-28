using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Persistense.Repositories
{
	public class WeatherForecastRepository : IWeatherForecastRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public WeatherForecastRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<WeatherForecast> GetWeatherForecasts(int page, int pageSize, int year, int month)
		{
			var min = new DateTime(year <= 0 ? DateTime.MinValue.Year : year, month <= 0 ? 1 : month, 1, 0, 0, 0);
			var max = new DateTime(year <= 0 ? DateTime.MaxValue.Year : year, month <= 0 ? 12 : month + 1, 1, 0, 0, 0);

			var timeZone = TimeZoneInfo.CreateCustomTimeZone("Moscow", TimeSpan.FromHours(3), null, null);
			min = TimeZoneInfo.ConvertTimeToUtc(min, timeZone);
			max = TimeZoneInfo.ConvertTimeToUtc(max, timeZone);

			return _dbContext.MoscowWeatherForecasts
				.Where(x => x.DateTime >= min && x.DateTime < max)
				.OrderBy(x => x.DateTime)
				.Skip(page * pageSize)
				.Take(pageSize)
				.ToList();
		}

		public void InsertWeatherForecasts(List<WeatherForecast> weatherForecasts)
		{
			foreach (var item in weatherForecasts)
			{
				var dublicate = _dbContext.MoscowWeatherForecasts.FirstOrDefault(x => x.DateTime == item.DateTime);
				if (dublicate is null)
					_dbContext.MoscowWeatherForecasts.Add(item);
				else
					_dbContext.MoscowWeatherForecasts.Update(item);
			}
		}

		public void SaveChanges()
			=> _dbContext.SaveChanges();
	}
}
