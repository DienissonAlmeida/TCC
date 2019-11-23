import { FlightReservation } from './flight-reservation';
import { FlightReservationFilter } from './flight-reservation-filter';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class FlightReservationService {

  constructor(private _httpClient: HttpClient) {
  }

  private URl: string = 'https://localhost:44301/api/flightreservation';
  flightList: FlightReservation[] = [];

  public getAll(): Observable<any> {
    return this._httpClient.get(this.URl);
    // .map((response: any) => response);

  }
  getByFlightId(flightId: number)  {
      let complete = `${this.URl}/flight/${flightId}`;
    return this._httpClient.get(complete);
  }

  getById(id: number)  {
      let complete = `${this.URl}/${id}`;
    return this._httpClient.get(complete);
  }

  getByFilter(hotelFilter: FlightReservationFilter) {

    return this._httpClient.get(`https://localhost:44301/api/flightreservation`);
  }

  deleteById(id: string): Observable<any> {
    let body = { "FlightReservationId": id };
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');

      return this._httpClient.request('delete', this.URl, { body });
  }

  save(entity: FlightReservation): Observable<FlightReservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.post<FlightReservation>(this.URl, entity, { headers });
  }

  update(entity: FlightReservation): Observable<FlightReservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.put<FlightReservation>(this.URl, entity, { headers });
  }

  // DeleteEmployee(emp: employee) {
  //   const params = new HttpParams().set('ID', emp.ID);
  //   const headers = new HttpHeaders().set('content-type', 'application/json');
  //   var body = {
  //     Fname: emp.Fname, Lname: emp.Lname, Email: emp.Email, ID: emp.ID
  //   }
  //   return this.http.delete<employee>(ROOT_URL + '/Employees/' + emp.ID)

  // }
}

