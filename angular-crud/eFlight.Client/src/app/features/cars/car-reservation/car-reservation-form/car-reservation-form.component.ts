// tslint:disable-next-line: quotemark
import { OnInit, Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { switchMap, map } from "rxjs/operators";
import { of } from "rxjs";
import { CarReservationService } from "../car-reservation.service";
import { CarReservation } from "../car-reservation";


@Component({
  selector: 'car-reservation-form',
  templateUrl: './car-reservation-form.component.html'
})
export class CarReservationFormComponent implements OnInit {

  id: string;
  carReservation: any;
  errors: string;
  IsUpdate: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private carReservationService: CarReservationService) {
  }

  ngOnInit() {
    var url = this.route.snapshot.url[1].path;

    if (url === "new") {
      this.route.params.pipe(
        map(p => p['carId']), switchMap(id => {
          this.IsUpdate = false;
          this.carReservation = new CarReservation(id);
          return of(this.carReservation);
        })
      )
        .subscribe(
          flightReservation => {
            if (this.IsUpdate === true) {
              this.carReservation = flightReservation;
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
          return this.carReservationService.getById(id);
        })
      )
        .subscribe(
          flightReservation => {
            if (this.IsUpdate === true) {
              this.carReservation = flightReservation;
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
    while (this.carReservation === undefined) {
      this.carReservation.inputDate.setMilliseconds(0);
      this.carReservation.inputDate.setSeconds(0);
      this.carReservation.outputDate.setSeconds(0);
      this.carReservation.outputDate.setMilliseconds(0);
    }
  }
  saveOrUpdate() { this.IsUpdate ? this.update() : this.save(); }

  update() {
    this.carReservationService.update(this.carReservation).subscribe(
      flightReservation => {
        this.carReservation = flightReservation;
        this.errors = 'Atualização de reserva efetuada com sucesso!';
        alert(this.errors);
        this.router.navigate(['/cars']);
      },
      err => {
        this.errors = 'Error saving';
      }
    );
  }
  save() {
    this.carReservationService.save(this.carReservation).subscribe(
      carReservation => {
        this.carReservation = carReservation;
        this.errors = 'Cadastro de reserva efetuado com sucesso!';
        alert(this.errors);
        this.router.navigate(['/cars']);
      },
      err => {
        this.errors = 'Error saving';
      }
    );
  }

  setDate(flightReservation: CarReservation) {
    // flightReservation.inputDate.se
  }
}
