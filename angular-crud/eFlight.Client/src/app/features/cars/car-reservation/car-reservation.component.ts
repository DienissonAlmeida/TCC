import { switchMap, map } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { CarReservationFilter } from './car-reservation-filter';
import { CarReservation } from './car-reservation';
import { CarReservationService } from './car-reservation.service';

@Component({
  selector: 'app-car-reservation',
  templateUrl: './car-reservation.component.html',
})
export class CarReservationComponent implements OnInit {

  id: string;
  messageResult: string;
  filter = new CarReservationFilter();
  selectedFlightReservation: CarReservation;
  flightReservationList: CarReservation[];

  constructor(private carRsvService: CarReservationService,
    private route: ActivatedRoute) {
     }

    ngOnInit() {
      this
      .route
      .params
      .pipe(
        map(p => p['id']),
        switchMap(id => {
            return this.carRsvService.getByCarId(id);
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

  select(selected: CarReservation): void {
      this.selectedFlightReservation = selected;
  }
  delete(id: string): void {
    console.log("chegando aqui" + id);

    this.carRsvService.deleteById(id).subscribe(
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


