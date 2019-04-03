import { ReservationService } from './reservation.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationListComponent } from './reservation-list/reservation-list.component';
import { ReservationEditComponent } from './reservation-edit/reservation-edit.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { RESERVATION_ROUTES } from './reservation.routes';

@NgModule({
  declarations: [
    ReservationListComponent,
    ReservationEditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(RESERVATION_ROUTES)
  ],
  providers : [ReservationService]
})
export class ReservationModule { }
