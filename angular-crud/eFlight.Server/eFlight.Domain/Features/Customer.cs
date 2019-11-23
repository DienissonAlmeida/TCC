using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Domain.Features.Flights
{
    public class Customer : Entity
    {
        public Customer()
        {

        }
        public string Name { get; set; }

        public string LastName { get; set; }

        public SexEnum Sex { get; set; }

        public FlightReservation FlightReservation { get; set; }

        public int? FlightReservationId { get; set; }

        public CarReservation CarReservation { get; set; }

        public int? CarReservationId { get; set; }

        public HotelReservation HotelReservation { get; set; }

        public int? HotelReservationId { get; set; }

        public TravelPackageReservation TravelPackageReservation { get; set; }

        public int? TravelPackageReservationId { get; set; }
    }
}
