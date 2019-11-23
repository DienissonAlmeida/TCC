import { HotelService } from './../hotel.service';
import { HotelFilter } from '../hotel-filter';
import { Hotel } from '../hotel';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'hotel',
  templateUrl: './hotel-list.component.html',
})
export class HotelListComponent implements OnInit {

  filter = new HotelFilter();
  selectedHotel: Hotel;
  hotelList: Hotel[];

  constructor(private _hotelService: HotelService) { }

  ngOnInit() {
    this._hotelService.getAll()
    .subscribe(dados => this.populaDados(dados));
  }

  populaDados(dados: any) {
    this.hotelList = dados;
    console.log(this.hotelList);
  }

  search(): void {
    if (this.filter.city !== "") {
      console.log('chegando com filtro: ' + this.filter.city);
      this._hotelService.getByFilter(this.filter)
      .subscribe(dados => this.populaDados(dados));
    } else {
      console.log('chegando sem filtro');
      this._hotelService.getAll()
      .subscribe(dados => this.populaDados(dados));
    }

  }

  select(selected: Hotel): void {
    this.selectedHotel = selected;
  }
}
