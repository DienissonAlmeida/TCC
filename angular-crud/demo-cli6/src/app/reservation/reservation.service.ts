import { Reservation } from './reservation';
import { ReservationFilter } from './reservation-filter';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable()
export class ReservationService {

    constructor(private http: HttpClient) {
    }

    reservationList: Reservation[] = [];

    findById(id: string): Observable<Reservation> {
        let url = 'https://localhost:44301/api/reservations';
        let params = { "id": id };
        let headers = new HttpHeaders()
                            .set('Accept', 'application/json');
        return this.http.get<Reservation>(url, {params, headers});
    }

    load(filter: ReservationFilter): void {
        this.find(filter).subscribe(
            result => {
                this.reservationList = result;
            },
            err => {
                console.error('error loading', err);
            }
        )
    }

    find(filter: ReservationFilter): Observable<Reservation[]> {
        let url = 'https://localhost:44301/api/reservations';
        let headers = new HttpHeaders()
                            .set('Accept', 'application/json');

        let params = {
            "from": filter.from,
            "to": filter.to,
        };

        return this.http.get<Reservation[]>(url, {params, headers});
    }

    save(entity: Reservation): Observable<Reservation> {
        let url = 'https://localhost:44301/api/reservations';
        let headers = new HttpHeaders()
            .set('Accept', 'application/json');
        return this.http.post<Reservation>(url, entity, {headers});
    }
}

