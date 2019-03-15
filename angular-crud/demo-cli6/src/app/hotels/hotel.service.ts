import { Hotel } from './hotel';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/observable';
import { HotelFilter } from './hotel-filter';


@Injectable()
export class HotelService {

    baseUrl: string = 'https://localhost:44301/api/hotels';

    constructor(private _httpClient: HttpClient) {
    }

    hotelList: Hotel[] = [];


    public getAll(): Observable<any> {

        return this._httpClient.get(`https://localhost:44301/api/hotels`);
        // .map((response: any) => response);

    }

    getByFilter(hotelFilter: HotelFilter) {

      return this._httpClient.get(`https://localhost:44301/api/hotels`);
    }

}

