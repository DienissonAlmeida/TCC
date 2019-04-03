import { ReservationListComponent } from './reservation-list/reservation-list.component';
import { Routes } from '@angular/router';
import { ReservationEditComponent } from './reservation-edit/reservation-edit.component';

export const RESERVATION_ROUTES: Routes = [
  {
    path: 'reservations',
    component: ReservationListComponent
  },
  {
    path: 'reservation/:id',
    component: ReservationEditComponent
  }
];
