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
    reservationList: any[];

    // get reservationList(): Reservation[] {
    //     return this.reservationService.reservationList;
    // }

    constructor(private reservationService: ReservationService) {
    }

    ngOnInit() {
      this.reservationService.getAll()
      .subscribe(dados => this.populaDados(dados));
    }

    populaDados(dados: any) {
      this.reservationList = dados;
      console.log(this.reservationList);
    }

    search(): void {
      if (this.filter.from !== "") {
        console.log('chegando com filtro: ' + this.filter.from);
        this.reservationService.getByFilter(this.filter)
        .subscribe(dados => this.populaDados(dados));
      } else {
        console.log('chegando sem filtro');
        this.reservationService.getAll()
        .subscribe(dados => this.populaDados(dados));
      }

    }

    select(selected: Reservation): void {
      this.selectedReservation = selected;
    }

}
