import { OnInit, Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { switchMap, map } from "rxjs/operators";
import { of } from "rxjs";
import { HotelReservationService } from "../hotel-reservation.service";
import { HotelReservation } from "../hotel-reservation";


@Component({
  selector: 'hotel-reservation-form',
  templateUrl: './hotel-reservation-form.component.html'
})
export class HotelReservationFormComponent implements OnInit {

  id: string;
  hotelReservation: any;
  errors: string;
  IsUpdate: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hotelReservationService: HotelReservationService) {
  }

  ngOnInit() {
    const url = this.route.snapshot.url[1].path;

    if (url === "new") {
      this.route.params.pipe(
        map(p => p['hotelId']), switchMap(id => {
          this.IsUpdate = false;
          this.hotelReservation = new HotelReservation(id);
          return of(this.hotelReservation);
        })
      )
        .subscribe(
          hotelReservation => {
            if (this.IsUpdate === true) {
              this.hotelReservation = hotelReservation;
              this.errors = '';
            }
          },
          err => {
            this.errors = 'Error loading';
          }
        );
    } else {
      this.route.params.pipe(
        map(p => p['id']), switchMap(id => {
          this.IsUpdate = true;
          return this.hotelReservationService.getById(id);
        })
      )
        .subscribe(
          hotelReservation => {
            if (this.IsUpdate === true) {
              this.hotelReservation = hotelReservation;
              this.errors = '';
            }
          },
          err => {
            this.errors = 'Error loading';
          }
        );
    }

  }

  // convertDate() {
  //   while (this.flightReservation === undefined) {
  //     this.flightReservation.inputDate.setMilliseconds(0);
  //     this.flightReservation.inputDate.setSeconds(0);
  //     this.flightReservation.outputDate.setSeconds(0);
  //     this.flightReservation.outputDate.setMilliseconds(0);
  //   }
  // }

  saveOrUpdate() { this.IsUpdate ? this.update() : this.save(); }

  update() {
    this.hotelReservationService.update(this.hotelReservation).subscribe(
      hotelReservation => {
        this.hotelReservation = hotelReservation;
        this.errors = 'Atualização de reserva efetuada com sucesso!';
        alert(this.errors);
        this.router.navigate(['/hotels']);
      },
      err => {
        this.errors = 'Error saving';
      }
    );
  }

  save() {
    this.hotelReservationService .save(this.hotelReservation).subscribe(
      hotelReservation => {
        this.hotelReservation = hotelReservation;
        this.errors = 'Cadastro de reserva efetuado com sucesso!';
        alert(this.errors);
        this.router.navigate(['/hotels']);
      },
      err => {
        this.errors = 'Error saving';
      }
    );
  }
}
