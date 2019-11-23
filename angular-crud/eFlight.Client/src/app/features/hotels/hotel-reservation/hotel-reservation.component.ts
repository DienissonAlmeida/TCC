import { switchMap, map } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HotelReservation } from './hotel-reservation';
import { HotelReservationService } from './hotel-reservation.service';
import { HotelReservationFilter } from './hotel-reservation-filter';

@Component({
  selector: 'app-hotel-reservation',
  templateUrl: './hotel-reservation.component.html',
})
export class HotelReservationComponent implements OnInit {

  id: string;
  messageResult: string;
   filter = new HotelReservationFilter();
  selectedHotelReservation: HotelReservation;
  hotelReservationList: HotelReservation[];

  constructor(private hotelService: HotelReservationService,
    private route: ActivatedRoute) {
     }

    ngOnInit() {
      this
      .route
      .params
      .pipe(
        map(p => p['id']),
        switchMap(id => {
            return this.hotelService.getByHotelId(id);
          }))
      .subscribe(dados => this.populaDados(dados));
  }

  populaDados(dados: any) {
    this.hotelReservationList = dados;
    console.log(this.hotelReservationList);
  }

  search(): void {
      console.log("nada por enquanto");
  }

  select(selected: HotelReservation): void {
      this.selectedHotelReservation = selected;
  }
  delete(id: string): void {
    console.log("chegando aqui" + id);

    this.hotelService.deleteById(id).subscribe(
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


