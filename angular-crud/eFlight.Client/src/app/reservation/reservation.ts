import { Car } from "../cars/car";
import { Hotel } from "../hotels/hotel";
import { User } from "../common/user";

export class Reservation {
    id: number;
    name: string;
    car: Car;
    hotel: Hotel;
    user: User;
}
