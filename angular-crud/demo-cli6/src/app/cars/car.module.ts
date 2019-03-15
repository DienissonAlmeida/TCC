import { CarService } from './car.service';
import { CAR_ROUTES } from './cars.routes';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarListComponent } from './car-list/car-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CarListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(CAR_ROUTES)
  ],
  providers: [
    CarService
  ]
})
export class CarModule { }
