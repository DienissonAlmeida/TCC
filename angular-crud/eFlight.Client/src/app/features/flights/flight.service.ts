import { Flight } from './flight';
import { FlightFilter } from './flight-filter';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable()
export class FlightService {

    constructor(private _httpClient: HttpClient) {
    }

    private URl: string = 'https://localhost:44301/api/flights';
    flightList: Flight[] = [];

    public getAll(): Observable<any> {

      return this._httpClient.get(`https://localhost:44301/api/flights`);
      // .map((response: any) => response);

  }

  getByFilter(hotelFilter: FlightFilter) {

    return this._httpClient.get(`https://localhost:44301/api/flights`);
  }

  findById(id: string): Observable<Flight> {
    let params = { "id": id };
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.get<Flight>(this.URl, { params, headers });
  }
  save(entity: Flight): Observable<Flight> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.post<Flight>(this.URl, entity, { headers });
  }
}

