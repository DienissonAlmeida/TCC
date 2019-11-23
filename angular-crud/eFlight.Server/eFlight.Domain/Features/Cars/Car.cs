using System.Collections.Generic;

namespace eFlight.Domain.Features.Cars
{
    public class Car : Entity
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        public int Passenger { get; set; }

        public Transmission Transmission { get; set; }

        public bool AirConditioning { get; set; }

        public string Photos { get; set; }

        public int AvailableVacancies { get; set; }

        public IList<CarReservation> CarReservations { get; set; }

    }
}
