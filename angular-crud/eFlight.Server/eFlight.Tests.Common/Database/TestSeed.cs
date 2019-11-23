using eFlight.Data.Context;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.TravelPackages;
using eFlight.Infra.Data.Features.Flights;
using eFlight.Infra.Data.Features.Hotels;
using eFlight.Tests.Common.Features;
using eFlight.Tests.Common.Features.Cars;
using eFlight.Tests.Common.Features.Flights;
using eFlight.Tests.Common.Features.Hotels;
using eFlight.Tests.Common.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace eFlight.Tests.Common.Database
{
    public class TestSeed
    {

        public FlightReservation FlightReservationSeedOne { get; private set; }
        public FlightReservation FlightReservationSeedTwo { get; private set; }
        public HotelReservation HotelReservationSeed { get; private set; }
        public TravelPackageReservation TravelPackageReservationSeed { get; private set; }
        public CarReservation CarReservationSeed { get; private set; }

        private eFlightDbContext _context;

        public TestSeed(eFlightDbContext context)
        {
            _context = context;
        }
        public TestSeed()
        {

        }

        public void RunSeed()
        {
            //Apagando e recriando o banco de dados
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //Salvando os objetos e atribuindo as instâncias as variáveis do seed
            CreateFlighReservation();
            CreateHotelReservation();
            CreateTravelPackageReservation();
            CreateCarReservation();

            //Confirmando alterações
            _context.SaveChanges();
        }

        private void CreateCarReservation()
        {
            CarReservationSeed = CarReservationBuilder.Start().WithCustomer(CustomerBuilder.Start().Build()).Build();
            //CarReservationSeed.SetId();

            //foreach (var customer in CarReservationSeed.CarCustomers)
            //{
            //    customer.SetId();
            //}

            CarReservationSeed = _context.CarReservation.Add(CarReservationSeed).Entity;

        }

        private void CreateTravelPackageReservation()
        {
            TravelPackageReservationSeed = TravelPackageReservationBuilder.Start().Build();
            //TravelPackageReservationSeed.SetId();

            //foreach (var customer in TravelPackageReservationSeed.TravelPackageCustomers)
            //{
            //    customer.SetId();
            //}

            TravelPackageReservationSeed = _context.TravelPackageReservation.Add(TravelPackageReservationSeed).Entity;
        }
    

        private void CreateFlighReservation()
        {
            FlightReservationSeedOne = FlightReservationBuilder.Start().WithCustomer(CustomerBuilder.Start().Build()).Build();
            //FlightReservationSeedOne.SetId();

            //foreach (var customer in FlightReservationSeedOne.FlightCustomers)
            //{
            //    customer.SetId();
            //}

            FlightReservationSeedTwo = FlightReservationBuilder.Start().WithCustomer(CustomerBuilder.Start().Build()).Build();
            //FlightReservationSeedTwo.SetId();

            //foreach (var customer in FlightReservationSeedTwo.FlightCustomers)
            //{
            //    customer.SetId();
            //}

            FlightReservationSeedOne = _context.FlightReservation.Add(FlightReservationSeedOne).Entity;
            FlightReservationSeedTwo = _context.FlightReservation.Add(FlightReservationSeedTwo).Entity;

        }

        private void CreateHotelReservation()
        {
            HotelReservationSeed = HotelReservationBuilder.Start().WithCustomer(CustomerBuilder.Start().Build()).Build();
            //HotelReservationSeed.SetId();

            //foreach (var customer in HotelReservationSeed.HotelCustomers)
            //{
            //    customer.SetId();
            //}

            HotelReservationSeed = _context.HotelReservation.Add(HotelReservationSeed).Entity;
        }
    }
}
