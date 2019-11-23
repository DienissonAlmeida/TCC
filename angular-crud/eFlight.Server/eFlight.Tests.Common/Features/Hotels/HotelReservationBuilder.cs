using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Hotels
{
    public class HotelReservationBuilder
    {
        private static HotelReservation _hotelReservation;

        public static HotelReservationBuilder Start()
        {
            _hotelReservation = new HotelReservation()
            {
                Description = "Reserva de Hotel",
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                Hotel = HotelBuilder.Start().Build(),
                HotelReservationCustomers = new List<Domain.Features.Flights.Customer>()
            };

            return new HotelReservationBuilder();
        }


        public HotelReservationBuilder WithHotel(Hotel hotel)
        {
            _hotelReservation.Hotel = hotel;
            return this;
        }
        public HotelReservationBuilder WithCustomer(Customer customer)
        {
            _hotelReservation.HotelReservationCustomers.Add(customer);
            return this;
        }

        public HotelReservationBuilder WithInputDate(DateTime inputDate)
        {
            _hotelReservation.InputDate = inputDate;
            return this;
        }
        public HotelReservationBuilder WithOutputDate(DateTime outputDate)
        {
            _hotelReservation.InputDate = outputDate;
            return this;
        }

        public HotelReservation Build() => _hotelReservation;
    }
}
