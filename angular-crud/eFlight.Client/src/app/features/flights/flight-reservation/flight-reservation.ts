export class FlightReservation {

  constructor(flightId: number){
    this.flightId = flightId;
  }
    id: number;
    flightId: number;
    description: string;
    inputDate: Date;
    outputDate: Date;
}
