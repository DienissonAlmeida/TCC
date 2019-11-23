using eFlight.Data.Context;
using eFlight.Tests.Common.Features.Cars;
using eFlight.Tests.Common.Features.Flights;
using eFlight.Tests.Common.Features.Hotels;
using eFlight.Tests.Common.Features.TravelPackages;
using System;

namespace eFliight.Integration.Tests
{
    public static class SeedData
    {
        public static void PopulateTestData(eFlightDbContext dbContext)
        {
            var flight = FlightBuilder.Start().WithVacancies(40).Build();
            var hotel = HotelBuilder.Start().Build();
            var car = CarBuilder.Start().Build();
            var travelPackage = TravelPackageBuilder.Start().Build();

            dbContext.Flight.Add(flight);
            dbContext.Hotel.Add(hotel);
            dbContext.Car.Add(car);
            dbContext.TravelPackage.Add(travelPackage);

            dbContext.FlightReservation.Add(FlightReservationBuilder.Start().WithFlight(flight).Build());
            dbContext.HotelReservation.Add(HotelReservationBuilder.Start().WithHotel(hotel).Build());
            dbContext.CarReservation.Add(CarReservationBuilder.Start().WithCar(car).Build());
            dbContext.TravelPackageReservation.Add(TravelPackageReservationBuilder.Start().WithTravelPackage(travelPackage).Build());

            dbContext.SaveChanges();
        }
    }
}