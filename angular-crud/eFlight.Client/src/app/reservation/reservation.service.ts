import { Reservation } from './reservation';
import { ReservationFilter } from './reservation-filter';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/observable";
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ReservationService {
  constructor(private _httpClient: HttpClient) {}

  hotelList: Reservation[] = [];

  public getAll(): Observable<any> {
    return this._httpClient.get(`https://localhost:44301/api/reservations`);
  }

  getByFilter(hotelFilter: ReservationFilter) {
    return this._httpClient.get(`https://localhost:44301/api/reservations`);
  }
}
