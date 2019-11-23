using System.Collections.Generic;

namespace eFlight.Domain.Features.Hotels
{
    public class Hotel : Entity
    {
        public string City { get; set; }

        public string Name { get; set; }

        public double Daily { get; set; }

        public int Stars { get; set; }

        public IList<HotelReservation> HotelReservations { get; set; }

        public int AvailableVacancies { get; set; }
    }
}
