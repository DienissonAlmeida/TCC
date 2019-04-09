import { Car } from "../cars/car";
import { Hotel } from "../hotels/hotel";
import { User } from "../common/user";

export class Reservation {
    id: number;
    Name: string;
    Car: Car;
    Hotel: Hotel;
    User: User;
}
