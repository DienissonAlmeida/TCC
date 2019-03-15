import { Routes } from '@angular/router';
import { HotelListComponent } from './hotel-list/hotel-list.component';

export const HOTEL_ROUTES: Routes = [
  {
    path: 'hotel',
    component: HotelListComponent
  }
//   {
//     path: 'hotel/:id',
//     component: FlightEditComponent
//   }
]