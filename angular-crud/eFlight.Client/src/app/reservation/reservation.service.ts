import { Reservation } from './reservation';
import { ReservationFilter } from './reservation-filter';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/observable";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ReservationService {

  private URl: string = 'https://localhost:44301/api/reservations';

  constructor(private _httpClient: HttpClient) { }

  hotelList: Reservation[] = [];

  public getAll(): Observable<any> {
    return this._httpClient.get(this.URl);
  }

  getByFilter(hotelFilter: ReservationFilter) {
    return this._httpClient.get(this.URl);
  }

  findById(id: string): Observable<Reservation> {
    let params = { "id": id };
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.get<Reservation>(this.URl, { params, headers });
  }
  save(entity: Reservation): Observable<Reservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.post<Reservation>(this.URl, entity, { headers });
  }
}
