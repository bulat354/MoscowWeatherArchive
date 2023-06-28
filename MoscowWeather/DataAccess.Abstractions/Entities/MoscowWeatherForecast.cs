﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class WeatherForecast
	{
		[Key]		public DateTime DateTime { get; set; }

		public double T { get; set; }
		public short Humidity { get; set; }
		public double Td { get; set; }
		public int AirPressure { get; set; }
		public string? WindDirection { get; set; }
		public int WindSpeed { get; set; }

		public short Cloudiness { get; set; }
		public int H { get; set; }
		public int VV { get; set; }
		public string? WeatherState { get; set; }
	}
}
