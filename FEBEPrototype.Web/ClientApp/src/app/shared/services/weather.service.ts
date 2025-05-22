import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Injectable({
    providedIn: 'root'
})
export class WeatherService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    }

    getWeather() {
        this.http.get(this.baseUrl + 'weatherforecast').subscribe(result => {
            console.log(result);
          }, error => console.error(error));
      
    }

}
