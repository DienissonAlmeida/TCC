import { Routes } from '@angular/router';
import { HotelListComponent } from './hotel-list/hotel-list.component';

export const HOTEL_ROUTES: Routes = [
  {
    path: 'hotels',
    component: HotelListComponent
  }
//   {
//     path: 'hotel/:id',
//     component: FlightEditComponent
//   }
]
