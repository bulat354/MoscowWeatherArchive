using AutoMapper;
using Domain.Repositories;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands
{
    public class GetWeatherForecastsCommand : IRequest<List<WeatherForecastDM>>
    {
        [Range(0, int.MaxValue)] public int Page { get; set; } = 0;
		[Range(0, int.MaxValue)] public int Count { get; set; } = 20;
		[Range(0, 9999)] public int Year { get; set; } = 0;
		[Range(0, 12)] public int Month { get; set; } = 0;

        public class GetWeatherForecastsCommandHandler : IRequestHandler<GetWeatherForecastsCommand, List<WeatherForecastDM>>
        {
            private readonly IWeatherForecastRepository _repository;
            private readonly IMapper _mapper;

            public GetWeatherForecastsCommandHandler(IWeatherForecastRepository repository, IMapper mapper)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<WeatherForecastDM>> Handle(GetWeatherForecastsCommand request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<WeatherForecastDM>>(_repository
                    .GetWeatherForecasts(request.Page, request.Count, request.Year, request.Month));
            }
        }
    }
}
