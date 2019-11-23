import { TravelPackage } from './travel-package';
import { TravelPackageFilter } from './reservation-filter';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/observable";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class TravelPackageService {

  private URl: string = 'https://localhost:44301/api/travelpackage';

  constructor(private _httpClient: HttpClient) { }

  hotelList: TravelPackage[] = [];

  public getAll(): Observable<any> {
    return this._httpClient.get(this.URl);
  }

  getByFilter(hotelFilter: TravelPackageFilter) {
    return this._httpClient.get(this.URl);
  }

  findById(id: string): Observable<TravelPackage> {
    let params = { "id": id };
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.get<TravelPackage>(this.URl, { params, headers });
  }
  save(entity: TravelPackage): Observable<TravelPackage> {
    let headers = new HttpHeaders()
      .set('Accept', 'application/json');
    return this._httpClient.post<TravelPackage>(this.URl, entity, { headers });
  }
}
