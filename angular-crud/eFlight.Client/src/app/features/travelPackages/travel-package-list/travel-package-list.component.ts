import { TravelPackageService } from './../travel-package.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { TravelPackageFilter } from '../reservation-filter';
import { TravelPackage } from '../travel-package';

@Component({
    selector: 'travel-package-list',
    templateUrl: 'travel-package-list.component.html'
})
export class TravelPackageListComponent {

    filter = new TravelPackageFilter();
    selectedReservation: TravelPackage;
    reservationList: TravelPackage[];

    // get reservationList(): Reservation[] {
    //     return this.reservationService.reservationList;
    // }

    constructor(private travelPackageService: TravelPackageService) {
    }

    ngOnInit() {
      this.travelPackageService.getAll()
      .subscribe(dados => this.populaDados(dados));
    }

    populaDados(dados: any) {
      this.reservationList = dados;
      console.log(this.reservationList);
    }

    search(): void {
      if (this.filter.from !== "") {
        console.log('chegando com filtro: ' + this.filter.from);
        this.travelPackageService.getByFilter(this.filter)
        .subscribe(dados => this.populaDados(dados));
      } else {
        console.log('chegando sem filtro');
        this.travelPackageService.getAll()
        .subscribe(dados => this.populaDados(dados));
      }

    }

    select(selected: TravelPackage): void {
      this.selectedReservation = selected;
    }

}
