import { FlightReservationComponent } from './flight-reservation/flight-reservation.component';
import { Routes } from '@angular/router';
import { FlightListComponent } from './flight-list/flight-list.component';
import { FlightReservationFormComponent } from './flight-reservation/flight-reservation-form/flight-reservation-form.component';

export const FLIGHT_ROUTES: Routes = [
  {
    path: 'flights',
    component: FlightListComponent
  },
  {
    path: 'flightReservationForm/:id',
    component: FlightReservationFormComponent
  },
  {
    path: 'flightReservationForm/new/:flightId',
    component: FlightReservationFormComponent
  },
  {
    path: 'flightReservation/:id',
    component: FlightReservationComponent
  }
];
