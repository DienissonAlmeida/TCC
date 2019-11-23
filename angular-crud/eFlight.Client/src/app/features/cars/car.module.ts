import { CarReservationComponent } from './car-reservation/car-reservation.component';
import { SharedModule } from './../../shared/shared-module.module';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarListComponent } from './car-list/car-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { CarService } from './car.service';
import { CAR_ROUTES } from './car.routes';
import { CarReservationFormComponent } from './car-reservation/car-reservation-form/car-reservation-form.component';
import { CarReservationService } from './car-reservation/car-reservation.service';

@NgModule({
  declarations: [
    CarListComponent,
    CarReservationFormComponent,
    CarReservationComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(CAR_ROUTES),
    SharedModule
  ],
  providers: [
    CarService,
    CarReservationService
  ]
})
export class CarModule { }
