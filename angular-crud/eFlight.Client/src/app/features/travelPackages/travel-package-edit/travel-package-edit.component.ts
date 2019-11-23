import { TravelPackageService } from './../travel-package.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TravelPackage } from '../travel-package';
import { map, switchMap } from "rxjs/operators";
import { of } from "rxjs";

@Component({
  selector: 'travel-package-edit',
  templateUrl: 'travel-package-edit.component.html'
})
export class TravelPackageEditComponent implements OnInit {
  id: string;
  travelPackage: TravelPackage;
  errors: string;

  constructor(
    private route: ActivatedRoute,
    private reservationService: TravelPackageService
  ) { }

  ngOnInit() {
    this.route.params
      .pipe(
        map(p => p["id"]),
        switchMap(id => {
          if (id === "new") return of(new TravelPackage());
          return this.reservationService.findById(id);
        })
      )
      .subscribe(
        reservation => {
          this.travelPackage = reservation;
          this.errors = "";
        },
        err => {
          this.errors = "Error loading";
        }
      );
  }

  save() {
    this.reservationService.save(this.travelPackage).subscribe(
      reservation => {
        this.travelPackage = reservation;
        this.errors = "Save was successful!";
      },
      err => {
        this.errors = "Error saving";
      }
    );
  }
}
