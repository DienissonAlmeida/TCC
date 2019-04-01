import { CarService } from './../car.service';
import { CarFilter } from './../car-filter';
import { Component, OnInit } from '@angular/core';
import { Car } from '../car';

@Component({
  selector: 'car',
  templateUrl: './car-list.component.html'
})
export class CarListComponent implements OnInit {

  filter = new CarFilter();
  selectedCar: Car;
  carList: Car[];

  constructor(private _carService: CarService) { }

  ngOnInit() {
    this._carService.getAll()
    .subscribe(dados => this.populaDados(dados));
  }

  populaDados(dados: any) {
    this.carList = dados;
    console.log(this.carList);
  }

  search(): void {
    if (this.filter.model !== "") {
      console.log('chegando com filtro: ' + this.filter.model);
      this._carService.getByFilter(this.filter)
      .subscribe(dados => this.populaDados(dados));
    } else {
      console.log('chegando sem filtro');
      this._carService.getAll()
      .subscribe(dados => this.populaDados(dados));
    }

  }

  select(selected: Car): void {
    this.selectedCar = selected;
  }

}
