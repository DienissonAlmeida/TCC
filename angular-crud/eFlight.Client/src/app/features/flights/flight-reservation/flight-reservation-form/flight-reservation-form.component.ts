import { OnInit, Component } from "@angular/core";
import { FlightReservation } from "../flight-reservation";
import { ActivatedRoute, Router } from "@angular/router";
import { FlightReservationService } from "../flight-reservation.service";
import { switchMap, map } from "rxjs/operators";
import { of } from "rxjs";


@Component({
  selector: 'flight-reservation-form',
  templateUrl: './flight-reservation-form.component.html'
})
export class FlightReservationFormComponent implements OnInit {

  id: string;
  flightReservation: any;
  errors: string;
  IsUpdate: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private flightReservationService: FlightReservationService) {
  }

  ngOnInit() {
    var url = this.route.snapshot.url[1].path;

    if (url === "new") {
      this.route.params.pipe(
        map(p => p['flightId']), switchMap(id => {
          this.IsUpdate = false;
          this.flightReservation = new FlightReservation(id);
          return of(this.flightReservation);
        })
      )
        .subscribe(
          flightReservation => {
            if (this.IsUpdate === true) {
              this.flightReservation = flightReservation;
              this.errors = '';
            }
          },
          err => {
            this.errors = 'Error loading';
          }
        );
    }
    else {
      this.route.params.pipe(
        map(p => p['id']), switchMap(id => {;
          this.IsUpdate = true;
          return this.flightReservationService.getById(id);
        })
      )
        .subscribe(
          flightReservation => {
            if (this.IsUpdate === true) {
              this.flightReservation = flightReservation;
              this.errors = '';
            }
          },
          err => {
            this.errors = 'Error loading';
          }
        );
    }

  }

  convertDate() {
    while (this.flightReservation === undefined) {
      this.flightReservation.inputDate.setMilliseconds(0);
      this.flightReservation.inputDate.setSeconds(0);
      this.flightReservation.outputDate.setSeconds(0);
      this.flightReservation.outputDate.setMilliseconds(0);
    }
  }
  saveOrUpdate() { this.IsUpdate ? this.update() : this.save(); }

  update() {
    this.flightReservationService.update(this.flightReservation).subscribe(
      flightReservation => {
        this.flightReservation = flightReservation;
        this.errors = 'Atualização de reserva efetuada com sucesso!';
        alert(this.errors);
        this.router.navigate(['/flights']);
      },
      err => {
        this.errors = 'Error saving';
      }
    );
  }
  save() {
    this.flightReservationService.save(this.flightReservation).subscribe(
      flightReservation => {
        this.flightReservation = flightReservation;
        this.errors = 'Cadastro de reserva efetuado com sucesso!';
        alert(this.errors);
        this.router.navigate(['/flights']);
      },
      err => {
        this.errors = 'Error saving';
      }
    );
  }

  setDate(flightReservation: FlightReservation) {
    // flightReservation.inputDate.se
  }
}
