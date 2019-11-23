using eFlight.Domain.Features.Hotels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Tests.Common.Features.Hotels
{
    public class HotelBuilder
    {
        private static Hotel _hotel;

        public static HotelBuilder Start()
        {
            _hotel = new Hotel()
            {
                City = "Paris",
                Name = "Hôtel Paris Lagayette",
                Daily = 500.00,
                Stars = 4,
                HotelReservations = new List<HotelReservation>()
            };

            return new HotelBuilder();
        }

        public Hotel Build() => _hotel;

        public HotelBuilder WithHotelReservation(HotelReservation hotelReservation)
        {
            _hotel.HotelReservations.Add(hotelReservation);
            return this;
        }
    }
}
