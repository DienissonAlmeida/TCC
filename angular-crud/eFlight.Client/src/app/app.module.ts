import { TravelPackageModule } from './features/travelPackages/travel-package.module';
import { CarModule } from './features/cars/car.module';
import { FlightModule } from './features/flights/flight.module';
import {HttpClientModule} from '@angular/common/http';

import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {APP_EXTRA_OPTIONS, APP_ROUTES} from './app.routes';
import {HomeComponent} from './home/home.component';
import {NavbarComponent} from './navbar/navbar.component';
import {SidebarComponent} from './sidebar/sidebar.component';
import { HotelModule } from './features/hotels/hotel.module';
import { FilterListPipe } from './shared/filter-list.pipe';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FlightModule,
    HotelModule,
    CarModule,
    TravelPackageModule,

    RouterModule.forRoot([...APP_ROUTES], {...APP_EXTRA_OPTIONS}),
  ],
  declarations: [
    AppComponent,
    SidebarComponent,
    NavbarComponent,
    HomeComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
