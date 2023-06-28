using AutoMapper;
using Domain.Entities;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			base.CreateMap<WeatherForecastCreateDM, WeatherForecast>();
			base.CreateMap<WeatherForecast, WeatherForecastDM>();
		}
	}
}
