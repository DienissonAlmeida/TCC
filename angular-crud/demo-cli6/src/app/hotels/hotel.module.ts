import { HotelService } from './hotel.service';
import { HOTEL_ROUTES } from './hotel.routes';
import { FormsModule } from '@angular/forms';


import {NgModule} from '@angular/core';
import { HotelListComponent } from './hotel-list/hotel-list.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(HOTEL_ROUTES)
  ],
  declarations: [
    HotelListComponent,
  ],
  providers: [
    HotelService
  ],
})
export class HotelModule {
}
