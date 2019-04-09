using System;
using System.Collections.Generic;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Domain.Features.Hotels
{
    public class Hotel : Entity
    {
        public string City { get; set; }

        public string Name { get; set; }

        public double Daily { get; set; }

        public int Stars { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
