import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ReservationFilter } from '../reservation-filter';
import { ReservationService } from '../reservation.service';
import { Reservation } from '../reservation';

@Component({
    selector: 'reservation',
    templateUrl: 'reservation-list.component.html'
})
export class ReservationListComponent {

    filter = new ReservationFilter();
    selectedReservation: Reservation;

    get reservationList(): Reservation[] {
        return this.reservationService.reservationList;
    }

    constructor(private reservationService: ReservationService) {
    }

    ngOnInit() {
        this.reservationService.load(this.filter);
    }

    search(): void {
        this.reservationService.load(this.filter);
    }

    select(selected: Reservation): void {
        this.selectedReservation = selected;
    }

}
