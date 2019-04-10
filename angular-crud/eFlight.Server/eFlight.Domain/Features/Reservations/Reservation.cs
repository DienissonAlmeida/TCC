using System;
using System.Collections.Generic;
using System.Text;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.Users;

namespace eFlight.Domain.Features.Reservations
{
    public class Reservation : Entity
    {
        public string Name { get; set; }

        public Hotel Hotel { get; set; }

        public int HotelId { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Flight Flight { get; set; }

        public int FlightId { get; set; }


    }
}
