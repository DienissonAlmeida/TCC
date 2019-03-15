import { Routes } from '@angular/router';
import { CarListComponent } from './car-list/car-list.component';
// import { FlightEditComponent } from './flight-edit/flight-edit.component';

export const CAR_ROUTES: Routes = [
  {
    path: 'cars',
    component: CarListComponent
  },
  // {
  //   path: 'flight/:id',
  //   component: CarslistComponent
  // }
]
