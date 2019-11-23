import { CarReservation } from './car-reservation';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CarReservationFilter } from './car-reservation-filter';

@Injectable()
export class CarReservationService {

  constructor(private _httpClient: HttpClient) {
  }

  private URl: string = 'https://localhost:44301/api/carreservation';
  flightList: CarReservation[] = [];

  public getAll(): Observable<any> {
    return this._httpClient.get(this.URl);
    // .map((response: any) => response);

  }
  getByCarId(carId: number)  {
      let complete = `${this.URl}/car/${carId}`;
    return this._httpClient.get(complete);
  }

  getById(id: number)  {
      let complete = `${this.URl}/${id}`;
    return this._httpClient.get(complete);
  }

  getByFilter(hotelFilter: CarReservationFilter) {

    return this._httpClient.get(`https://localhost:44301/api/flightreservation`);
  }

  deleteById(id: string): Observable<any> {
    let body = { "CarReservationId": id };
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');

      return this._httpClient.request('delete', this.URl, { body });
  }

  save(entity: CarReservation): Observable<CarReservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.post<CarReservation>(this.URl, entity, { headers });
  }

  update(entity: CarReservation): Observable<CarReservation> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.put<CarReservation>(this.URl, entity, { headers });
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

