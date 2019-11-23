import { HotelReservationFormComponent } from './hotel-reservation/hotel-reservation-form/hotel-reservation-form.component';
import { Routes } from '@angular/router';
import { HotelListComponent } from './hotel-list/hotel-list.component';
import { HotelReservationComponent } from './hotel-reservation/hotel-reservation.component';

export const HOTEL_ROUTES: Routes = [
  {
    path: 'hotels',
    component: HotelListComponent
  },
  {
    path: 'hotelReservationForm/:id',
    component: HotelReservationFormComponent
  },
  {
    path: 'hotelReservationForm/new/:hotelId',
    component: HotelReservationFormComponent
  },
  {
    path: 'hotelReservation/:id',
    component: HotelReservationComponent
  }
];
