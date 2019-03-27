﻿using System;

namespace TestEstrategyTurism.Domain.Features.Cars

{
    public class Car : Entity
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        public int Passengers { get; set; }

        public Transmission Transmission { get; set; }

        public bool AirConditioning { get; set; }

        public string Photos { get; set; }
    }
}
