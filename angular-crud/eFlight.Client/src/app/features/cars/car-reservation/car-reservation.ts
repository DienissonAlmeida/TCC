export class CarReservation {

  constructor(carId: number) {
    this.carId = carId;
  }
    id: number;
    carId: number;
    name: string;
    inputDate: Date;
    outputDate: Date;
    airConditioning: boolean;
}
