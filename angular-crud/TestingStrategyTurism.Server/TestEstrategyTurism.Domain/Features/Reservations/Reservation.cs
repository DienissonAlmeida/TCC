using System;
using System.Collections.Generic;
using System.Text;
using TestEstrategyTurism.Domain.Features.Cars;
using TestEstrategyTurism.Domain.Features.Hotels;
using TestEstrategyTurism.Domain.Features.Users;

namespace TestEstrategyTurism.Domain.Features.Reservations
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

    }
}
