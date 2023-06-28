using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
	public class WeatherForecastCreateDM
	{
		[Column(0, CustomFormat = "dd.MM.yyyy")] public DateTime DateTime { get; set; }
		[Column(1, CustomFormat = "HH:mm")] public DateTime Time { get; set; }
		[Column(2)] public double T { get; set; }
		[Column(3)] public short Humidity { get; set; }
		[Column(4)] public double Td { get; set; }
		[Column(5)] public int AirPressure { get; set; }
		[Column(6)] public string WindDirection { get; set; }
		[Column(7)] public int WindSpeed { get; set; }
		[Column(8)] public short Cloudiness { get; set; }
		[Column(9)] public int H { get; set; }
		[Column(10)] public int VV { get; set; }
		[Column(11)] public string WeatherState { get; set; }
	}
}
