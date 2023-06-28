export interface IWeatherForecast {

    dateTime: Date,
    t: number,
    humidity: number,
    td: number,
    airPressure: number,
    windDirection: string,
    windSpeed: number,
    cloudiness: number,
    h: number,
    vv: number,
    weatherState: string
    /*
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
		public string? WeatherState { get; set; } */
}