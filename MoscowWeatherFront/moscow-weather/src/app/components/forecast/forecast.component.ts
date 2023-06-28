import { Component, Input } from '@angular/core';
import { IWeatherForecast } from 'src/app/models/weather-forecast';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.scss']
})
export class ForecastComponent {
  @Input() forecast: IWeatherForecast
}
