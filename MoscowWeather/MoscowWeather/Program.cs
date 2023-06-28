using Application.Commands;
using Application.Mappings;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistense;
using Persistense.Repositories;

namespace MoscowWeather
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("angular", builder => 
				{
					builder.WithOrigins("https://localhost:4200");
					builder.AllowAnyHeader();
					builder.AllowAnyMethod();
					
				});
			});

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("PosgreConnectionString");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
				if (builder.Environment.IsDevelopment())
				{
					options.EnableSensitiveDataLogging();
				}
			}, ServiceLifetime.Scoped);
			builder.Services.AddMediatR(options =>
				{
					options.RegisterServicesFromAssembly(typeof(AddWeatherForecastsCommand).Assembly);
				});

			builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
			builder.Services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			app.UseCors("angular");

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseHsts();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}