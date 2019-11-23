export class HotelReservation {

  constructor(hotelId: number) {
    this.hotelId = hotelId;
  }
    id: number;
    hotelId: number;
    description: string;
    inputDate: Date;
    outputDate: Date;
}
