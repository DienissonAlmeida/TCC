import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ReservationService } from "../reservation.service";
import { Reservation } from "../reservation";
import { map, switchMap } from "rxjs/operators";
import { of } from "rxjs";

@Component({
  selector: "reservation-edit",
  templateUrl: "reservation-edit.component.html"
})
export class ReservationEditComponent implements OnInit {
  id: string;
  reservation: Reservation;
  errors: string;

  constructor(
    private route: ActivatedRoute,
    private reservationService: ReservationService
  ) {}

  ngOnInit() {
    this.route.params
      .pipe(
        map(p => p["id"]),
        switchMap(id => {
          if (id === "new") return of(new Reservation());
          return this.reservationService.findById(id);
        })
      )
      .subscribe(
        reservation => {
          this.reservation = reservation;
          this.errors = "";
        },
        err => {
          this.errors = "Error loading";
        }
      );
  }

  save() {
    this.reservationService.save(this.reservation).subscribe(
      reservation => {
        this.reservation = reservation;
        this.errors = "Save was successful!";
      },
      err => {
        this.errors = "Error saving";
      }
    );
  }
}
