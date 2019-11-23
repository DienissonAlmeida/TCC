import { TravelPackageService } from './travel-package.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TravelPackageListComponent } from './travel-package-list/travel-package-list.component';
import { TravelPackageEditComponent } from './travel-package-edit/travel-package-edit.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TRAVELPACKAGE_ROUTES } from './travel-package.routes';

@NgModule({
  declarations: [
    TravelPackageListComponent,
    TravelPackageEditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(TRAVELPACKAGE_ROUTES)
  ],
  providers : [TravelPackageService]
})
export class TravelPackageModule { }
