import { HotelReservation } from './hotel-reservation';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class HotelReservationService {

  constructor(private _httpClient: HttpClient) {
  }

  private URl: string = 'https://localhost:44301/api/hotelreservation';
  // flightList: HotelReservation[] = [];

  public getAll(): Observable<any> {
    return this._httpClient.get(this.URl);
    // .map((response: any) => response);

  }
  getByHotelId(hotelId: number)  {
      let complete = `${this.URl}/hotel/${hotelId}`;
    return this._httpClient.get(complete);
  }

  getById(id: number)  {
      let complete = `${this.URl}/${id}`;
    return this._httpClient.get(complete);
  }

  // getByFilter(hotelFilter: FlightReservationFilter) {

  //   return this._httpClient.get(this.URl);
  // }

  deleteById(id: string): Observable<any> {
    let body = { "HotelReservationId": id };
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');

      return this._httpClient.request('delete', this.URl, { body });
  }

  save(entity: HotelReservation): Observable<HotelReservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.post<HotelReservation>(this.URl, entity, { headers });
  }

  update(entity: HotelReservation): Observable<HotelReservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.put<HotelReservation>(this.URl, entity, { headers });
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

