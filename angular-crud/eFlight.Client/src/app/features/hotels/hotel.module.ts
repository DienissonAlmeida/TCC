import { SharedModule } from './../../shared/shared-module.module';
import { HotelService } from './hotel.service';
import { HOTEL_ROUTES } from './hotel.routes';
import { FormsModule } from '@angular/forms';


import {NgModule} from '@angular/core';
import { HotelListComponent } from './hotel-list/hotel-list.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HotelReservationService } from './hotel-reservation/hotel-reservation.service';
import { HotelReservationComponent } from './hotel-reservation/hotel-reservation.component';
import { HotelReservationFormComponent } from './hotel-reservation/hotel-reservation-form/hotel-reservation-form.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(HOTEL_ROUTES),
    SharedModule
  ],
  declarations: [
    HotelListComponent,
    HotelReservationFormComponent,
    HotelReservationComponent,
  ],
  providers: [
    HotelService,
    HotelReservationService
  ],
})
export class HotelModule {
}
