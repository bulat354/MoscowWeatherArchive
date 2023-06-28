using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Application.Models;
using MediatR;
using Npoi.Mapper;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Commands
{
	public class AddWeatherForecastsCommand : IRequest
	{
		public Stream FileStream { get; set; }

		public class AddWeatherForecastsCommandHandler : IRequestHandler<AddWeatherForecastsCommand>
		{
			private readonly IWeatherForecastRepository _repository;
			private readonly IMapper _mapper;

			public AddWeatherForecastsCommandHandler(IWeatherForecastRepository repository, IMapper mapper)
			{
				_repository = repository ?? throw new ArgumentNullException(nameof(repository));
				_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			}

			public async Task Handle(AddWeatherForecastsCommand request, CancellationToken cancellationToken)
			{
				if (request.FileStream == null)
					throw new FileNotUploadedException("Excel file didn't attached");

				using var stream = request.FileStream;
				var mapper = new Npoi.Mapper.Mapper(stream) { HasHeader = false, FirstRowIndex = 4 };

				for (var i = 0; i < mapper.Workbook.NumberOfSheets; i++)
				{
					var forecasts = mapper
						.Take<WeatherForecastCreateDM>(i)
						.Select(x =>
						{
							var val = x.Value;
							var timeZone = TimeZoneInfo.CreateCustomTimeZone("Moscow", TimeSpan.FromHours(3), null, null);
							val.DateTime = TimeZoneInfo.ConvertTimeToUtc(val.DateTime, timeZone).AddHours(val.Time.Hour).AddMinutes(val.Time.Minute);
							return val;
						})
						.Where(x => x.DateTime != default)
						.ToList();
					_repository.InsertWeatherForecasts(_mapper.Map<List<WeatherForecast>>(forecasts));
					_repository.SaveChanges();
				}
			}
		}
	}
}
