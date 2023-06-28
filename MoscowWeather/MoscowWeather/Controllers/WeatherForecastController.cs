using Application.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoscowWeather.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IMediator _mediator;

		public WeatherForecastController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet()]
		public async Task<List<WeatherForecastDM>> Get([FromQuery] GetWeatherForecastsCommand props)
		{
			if (!ModelState.IsValid) return new List<WeatherForecastDM>();
			return await _mediator.Send(props);
		}

		[HttpPost()]
		public async Task<IActionResult> Add([FromForm] List<IFormFile> file)
		{
			foreach (var item in file)
			{
				try
				{
					await _mediator.Send(new AddWeatherForecastsCommand() { FileStream = item.OpenReadStream() });
				}
				catch (Exception ex)
				{
					return BadRequest($"Error in file '{item.FileName}'. Message: '{ex.Message}'");
				}
			}
			return Ok();
		}
	}
}