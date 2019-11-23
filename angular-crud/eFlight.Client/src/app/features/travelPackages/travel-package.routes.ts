import { TravelPackageListComponent } from './travel-package-list/travel-package-list.component';
import { Routes } from '@angular/router';
import { TravelPackageEditComponent } from './travel-package-edit/travel-package-edit.component';

export const TRAVELPACKAGE_ROUTES: Routes = [
  {
    path: 'travelPackages',
    component: TravelPackageListComponent
  },
  {
    path: 'travelPackage/:id',
    component: TravelPackageEditComponent
  }
];
