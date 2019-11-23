import { Component, OnInit } from '@angular/core';
import { FlightFilter } from '../flight-filter';
import { FlightService } from '../flight.service';
import { Flight } from '../flight';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'flight',
    templateUrl: 'flight-list.component.html'
})
export class FlightListComponent implements OnInit {

    filter = new FlightFilter();
    selectedFlight: Flight;
    flightList: Flight[];

    constructor(private flightService: FlightService,
      private router: RouterModule) {
    }

    ngOnInit() {
        this.flightService.getAll()
        .subscribe(dados => this.populaDados(dados));
    }

    populaDados(dados: any) {
      this.flightList = dados;
      console.log(this.flightList);
    }

    search(): void {
        console.log("nada por enquanto");
    }

    select(selected: Flight): void {
        this.selectedFlight = selected;
    }

}
