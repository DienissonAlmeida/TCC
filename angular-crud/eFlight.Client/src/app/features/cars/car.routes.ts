import { Routes } from '@angular/router';
import { CarListComponent } from './car-list/car-list.component';
import { CarReservationFormComponent } from './car-reservation/car-reservation-form/car-reservation-form.component';
import { CarReservationComponent } from './car-reservation/car-reservation.component';
// import { FlightEditComponent } from './flight-edit/flight-edit.component';

export const CAR_ROUTES: Routes = [
  {
    path: 'cars',
    component: CarListComponent
  },
  {
    path: 'carReservationForm/:id',
    component: CarReservationFormComponent
  },
  {
    path: 'carReservationForm/new/:carId',
    component: CarReservationFormComponent
  },
  {
    path: 'carReservation/:id',
    component: CarReservationComponent
  }
]
