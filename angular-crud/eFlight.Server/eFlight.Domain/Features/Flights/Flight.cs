using System;
using System.Collections.Generic;
using System.Linq;

namespace eFlight.Domain.Features.Flights
{
    public class Flight : Entity
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public string Company { get; set; }

        public int AvailableVacancies { get; set; }
        public IList<FlightReservation> FlightReservations { get; set; }

    }
}
