import { SharedModule } from './../shared/shared-module.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarListComponent } from './car-list/car-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { CarService } from './car.service';
import { CAR_ROUTES } from './car.routes';

@NgModule({
  declarations: [
    CarListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(CAR_ROUTES),
    SharedModule
  ],
  providers: [
    CarService
  ]
})
export class CarModule { }
