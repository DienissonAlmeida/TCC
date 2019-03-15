import { Hotel } from './hotel';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/observable';


@Injectable()
export class HotelService {

    baseUrl: string = 'https://localhost:44301/api/hotels';
    
    constructor(private _httpClient: HttpClient) {
    }

    hotelList: Hotel[] = [];
    

    public getAll(): Observable<any> {

        var result = this._httpClient.get(`https://httpbin.org/get`);
        // .map((response: any) => response);
        return result;
    }

}

