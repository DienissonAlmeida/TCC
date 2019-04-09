﻿using System;
using System.Collections.Generic;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Domain.Features.Cars

{
    public class Car : Entity
    {
        public Car()
        {

        }
        public string Model { get; set; }

        public string Brand { get; set; }

        public int Passengers { get; set; }

        public Transmission Transmission { get; set; }

        public bool AirConditioning { get; set; }

        public string Photos { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
