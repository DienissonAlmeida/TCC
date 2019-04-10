using eFlight.Domain.Features.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Domain.Features.Flights
{
    public class Flight : Entity
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime Out { get; set; }

        public DateTime Return { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
