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

  // get hotelList(): Hotel[] {
  //   this._hotelService.hotelList.forEach(element => {
  //     console.log(element);
  //   });

  //   return this._hotelService.hotelList;
  // }

  ngOnInit() {
    this._hotelService.getAll()
    .map(dados => JSON.stringify(dados))
    .subscribe(dados => this.populaDados(dados));
  }

  populaDados(dados: any) {
    console.log("indo na api")
    console.log(dados);
  }

  search(): void {
    // this._hotelService.load(this.filter);
    throw new Error("não implementado");
  }

  select(selected: Hotel): void {
    this.selectedHotel = selected;
  }
}
