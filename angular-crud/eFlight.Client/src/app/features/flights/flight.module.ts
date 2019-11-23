import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './flight-list/flight-list.component';
import { FlightReservationFormComponent } from './flight-reservation/flight-reservation-form/flight-reservation-form.component';
import { FlightService } from './flight.service';
import { FLIGHT_ROUTES } from './flight.routes';
import { FlightReservationComponent } from './flight-reservation/flight-reservation.component';
import { FlightReservationService } from './flight-reservation/flight-reservation.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(FLIGHT_ROUTES)
  ],
  declarations: [
    FlightListComponent,
    FlightReservationFormComponent,
    FlightReservationComponent,
  ],
  providers: [
    FlightService,
    FlightReservationService
  ]

})
export class FlightModule { }
