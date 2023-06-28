import {Injectable} from "@angular/core"
import {HttpClient} from "@angular/common/http"
import { IWeatherForecast } from "../models/weather-forecast"
import { Observable } from "rxjs"

@Injectable({
    providedIn: "root"
})
export class WeatherService {
    constructor(private http: HttpClient) { }

    getWeatherForecasts(page: number, count: number, year?: number | undefined, month?: number | undefined)
        : Observable<IWeatherForecast[]> {
        return this.http.get<IWeatherForecast[]>('https://localhost:5126/api/v1/weatherforecast', {
            params: {
                page: page,
                count: count ? count : 20,
                year: year ? year : 0,
                month: month ? month : 0
            }
        })
    }
}