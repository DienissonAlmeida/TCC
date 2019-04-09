import { SharedModule } from './../shared/shared-module.module';
import { HotelService } from './hotel.service';
import { HOTEL_ROUTES } from './hotel.routes';
import { FormsModule } from '@angular/forms';


import {NgModule} from '@angular/core';
import { HotelListComponent } from './hotel-list/hotel-list.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FilterListPipe } from '../shared/filter-list.pipe';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(HOTEL_ROUTES),
    SharedModule
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
