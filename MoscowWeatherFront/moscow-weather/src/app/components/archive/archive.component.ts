import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IWeatherForecast } from 'src/app/models/weather-forecast';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.scss']
})

export class ArchiveComponent implements OnInit {
  
  count: number = 20
  page: number = 0
  year: number;
  month: number;
  monthName: string = "Any month"
  monthNames = ["January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
  ];

  protected data: IWeatherForecast[] = []
  dtOptions: DataTables.Settings = {};

  constructor(private weatherService: WeatherService, private http: HttpClient) {}

  ngOnInit(): void {
    this.dtOptions = {
      processing: false,
      searching: false,
      paging: false,
      ordering: false,
      pageLength: 20,
      ajax: {
        url: 'https://localhost:5126/api/v1/weatherforecast',
        method: 'get'
      }
    };
    this.loadData()
  }
  
  loadData() {
    this.weatherService.getWeatherForecasts(this.page, this.count, this.year, this.month)
      .subscribe(result => {
        this.data = result
        console.log(result)
      })
  }

  nextPage() {
    this.page++
    this.loadData()
  }

  prevPage() {
    this.page--
    this.loadData()
  }

  deltaMonth(delta: number) {
    let date = new Date()
    if (!this.year) this.year = date.getFullYear()
    if (!this.month) this.month = 1

    this.month += delta
    if (this.month > 12) {
      this.month = 1
      this.year += 1
    }
    else if (this.month < 1) {
      this.month = 12
      this.year -= 1
    }

    this.monthName = this.monthNames[this.month - 1]

    this.loadData()
  }

  deltaYear(delta: number) {
    let date = new Date()
    if (!this.year) this.year = date.getFullYear()

    this.year += delta

    this.loadData()
  }

  setCount(newCount: number) {
    this.count = newCount

    this.loadData()
  }
}
