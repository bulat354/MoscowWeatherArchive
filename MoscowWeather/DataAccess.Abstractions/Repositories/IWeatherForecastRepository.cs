using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IWeatherForecastRepository
	{
		public List<WeatherForecast> GetWeatherForecasts(int page, int pageSize, int year, int month);

		public void InsertWeatherForecasts(List<WeatherForecast> weatherForecasts);

		public void SaveChanges();
	}
}
