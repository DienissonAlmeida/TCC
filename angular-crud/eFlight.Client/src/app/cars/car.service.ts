import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from './car';
import { CarFilter } from './car-filter';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor(private _httpClient: HttpClient) { }

  hotelList: Car[] = [];

  public getAll(): Observable<any> {
      return this._httpClient.get(`https://localhost:44301/api/cars`);
  }

  getByFilter(hotelFilter: CarFilter) {
    return this._httpClient.get(`https://localhost:44301/api/cars`);
  }
}
