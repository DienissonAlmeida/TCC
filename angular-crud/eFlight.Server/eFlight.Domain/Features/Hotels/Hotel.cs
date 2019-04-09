using System;
using System.Collections.Generic;
using eFlight.Domain.Features.Reservations;

namespace eFlight.Domain.Features.Hotels
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
