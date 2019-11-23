using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Cars
{
    public class CarReservationBuilder
    {
        private static CarReservation _carReservation;

        public static CarReservationBuilder Start()
        {
            _carReservation = new CarReservation()
            {
                Name = "Reserva de carro",
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                Car = CarBuilder.Start().Build(),
                CarReservationCustomers = new List<Domain.Features.Flights.Customer>()
            };

            return new CarReservationBuilder();
        }

        public CarReservationBuilder WithCustomer(Customer customer)
        {
            _carReservation.CarReservationCustomers.Add(customer);
            return this;
        }

        public CarReservation Build() => _carReservation;

        public CarReservationBuilder WithCar(Car car)
        {
            _carReservation.Car = car;
            return this;
        }

        public CarReservationBuilder WithInputDate(DateTime date)
        {
            _carReservation.InputDate = date;
            return this;
        }

        public CarReservationBuilder WithOutputDate(DateTime date)
        {
            _carReservation.OutputDate = date;
            return this;
        }
    }
}
