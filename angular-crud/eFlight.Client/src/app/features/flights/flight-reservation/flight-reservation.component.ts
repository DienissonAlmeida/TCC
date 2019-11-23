import { switchMap, map } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { FlightReservationService } from './flight-reservation.service';
import { FlightReservation } from './flight-reservation';
import { FlightReservationFilter } from './flight-reservation-filter';
import { RouterModule, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-flight-reservation',
  templateUrl: './flight-reservation.component.html',
})
export class FlightReservationComponent implements OnInit {

  id: string;
  messageResult: string;
  filter = new FlightReservationFilter();
  selectedFlightReservation: FlightReservation;
  flightReservationList: FlightReservation[];

  constructor(private flightService: FlightReservationService,
    private route: ActivatedRoute) {
     }

    ngOnInit() {
      this
      .route
      .params
      .pipe(
        map(p => p['id']),
        switchMap(id => {
            return this.flightService.getByFlightId(id);
          }))
      .subscribe(dados => this.populaDados(dados));
  }

  populaDados(dados: any) {
    this.flightReservationList = dados;
    console.log(this.flightReservationList);
  }

  search(): void {
      console.log("nada por enquanto");
  }

  select(selected: FlightReservation): void {
      this.selectedFlightReservation = selected;
  }
  delete(id: string): void {
    console.log("chegando aqui" + id);

    this.flightService.deleteById(id).subscribe(
      x => {
        this.messageResult = 'Reserva deletada com sucesso!';
        alert(this.messageResult);
        window.location.reload();
      },
      err => {
        this.messageResult = 'Não foi possível deletar reserva!';
        alert(this.messageResult);
      }
    );
  }

}


