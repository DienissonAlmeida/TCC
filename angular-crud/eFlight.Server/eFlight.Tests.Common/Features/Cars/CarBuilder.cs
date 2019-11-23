using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Cars
{
    public class CarBuilder
    {
        private static Car _car;

        public static CarBuilder Start()
        {
            _car = new Car()
            {
                Model = "C4",
                AirConditioning = true,
                Brand = "Citroen",
                Transmission = Transmission.Manual,
                Passenger = 5,
                Photos = null,
                CarReservations = new List<CarReservation>()
            };

            return new CarBuilder();
        }

        public Car Build() => _car;

        public CarBuilder WithCarReservation(CarReservation reservation)
        {
            _car.CarReservations.Add(reservation);
            return this;
        }

    }
}
