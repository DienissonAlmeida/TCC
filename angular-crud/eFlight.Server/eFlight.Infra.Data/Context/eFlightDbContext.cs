using eFlight.Data.Features.Cars;
using eFlight.Data.Features.Hotels;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.TravelPackages;
using eFlight.Domain.Features.Users;
using eFlight.Infra.Data.Features;
using eFlight.Infra.Data.Features.Cars;
using eFlight.Infra.Data.Features.Flights;
using eFlight.Infra.Data.Features.Hotels;
using eFlight.Infra.Data.Features.TravelPackages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace eFlight.Data.Context
{
    public class eFlightDbContext : DbContext
    {
        public eFlightDbContext(DbContextOptions<eFlightDbContext> options) : base(options)
        {

        }


        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TravelPackage> TravelPackage { get; set; }
        public DbSet<HotelReservation> HotelReservation { get; set; }
        public DbSet<CarReservation> CarReservation { get; set; }
        public DbSet<FlightReservation> FlightReservation { get; set; }
        public DbSet<TravelPackageReservation> TravelPackageReservation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelReservationEntityConfiguration());

            modelBuilder.ApplyConfiguration(new FlightEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FlightReservationEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelReservationEntityConfiguration());

            modelBuilder.ApplyConfiguration(new TravelPackageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TravelPackageReservationEntityConfiguration());

            CreateRelationships(modelBuilder);

            base.OnModelCreating(modelBuilder);

            if (this.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
                return;

            SeedData(modelBuilder);
        }


        private static void CreateRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(x => x.HotelReservations)
                .WithOne(p => p.Hotel);

            modelBuilder.Entity<Car>()
                 .HasMany(c => c.CarReservations)
                    .WithOne(e => e.Car);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.FlightReservations)
                    .WithOne(p => p.Flight);

            modelBuilder.Entity<TravelPackage>()
                .HasMany(f => f.TravelPackageReservations)
                    .WithOne(p => p.TravelPackage);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelEntityConfiguration()).Entity<Hotel>()
                .HasData(
                    new Hotel { Id = 1, Name = "Hotel Darcet", City = "Paris", Daily = 397, Stars = 4 },
                    new Hotel { Id = 2, Name = "Hôtel La Manufacture", City = "Paris", Daily = 338, Stars = 4 },
                    new Hotel { Id = 3, Name = "Hotel Italia", City = "Roma", Daily = 859, Stars = 4 },
                    new Hotel { Id = 4, Name = "Best Western Plus Hotel Universo", City = "Roma", Daily = 611, Stars = 4 },
                    new Hotel { Id = 5, Name = "Hotel Colosseum", City = "Roma", Daily = 592, Stars = 4 },
                    new Hotel { Id = 6, Name = "SIXTY SoHo", City = "Nova Yorque", Daily = 1.058, Stars = 4 },
                    new Hotel { Id = 7, Name = "YOTEL New York", City = "Nova Yorque", Daily = 522, Stars = 4 },
                    new Hotel { Id = 8, Name = "Hotel Arpoador", City = "Rio de Janeiro", Daily = 533, Stars = 4 },
                    new Hotel { Id = 9, Name = "Prodigy Hotel Santos Dumont Airport", City = "Rio de Janeiro", Daily = 338, Stars = 4 }
                    );


            modelBuilder.ApplyConfiguration(new CarEntityConfiguration()).Entity<Car>()
                .HasData(
                    new Car { Id = 1, Model = "C4", Brand = "Citroen", AirConditioning = true, Passenger = 5, Transmission = Transmission.Manual },
                    new Car { Id = 2, Model = "New Fiesta", Brand = "Ford", AirConditioning = true, Passenger = 5, Transmission = Transmission.Manual },
                    new Car { Id = 3, Model = "Onix", Brand = "Chevrolet", AirConditioning = true, Passenger = 5, Transmission = Transmission.Manual },
                    new Car { Id = 4, Model = "HB20", Brand = "Hyundai", AirConditioning = true, Passenger = 5, Transmission = Transmission.Manual },
                    new Car { Id = 5, Model = "Gol", Brand = "Volkswagen", AirConditioning = true, Passenger = 5, Transmission = Transmission.Manual },
                    new Car { Id = 6, Model = "Argo", Brand = "Fiat", AirConditioning = true, Passenger = 5, Transmission = Transmission.Manual }
                    );


            modelBuilder.ApplyConfiguration(new FlightEntityConfiguration()).Entity<Flight>()
                .HasData(
                new Flight { Id = 1, Origin = "São Paulo", Destination = "Paris", Company = "Gol", AvailableVacancies = 40 },
                new Flight { Id = 2, Origin = "Rio de Janeiro", Destination = "Nova Iorque", Company = "TAM", AvailableVacancies = 40 }
                );

            modelBuilder.ApplyConfiguration(new TravelPackageEntityConfiguration()).Entity<TravelPackage>()
                .HasData(
                    new TravelPackage { Id = 1, Name = "Pacote Buenos Aires" },
                    new TravelPackage { Id = 2, Name = "Pacote Paris" }
                );

            modelBuilder.ApplyConfiguration(new FlightReservationEntityConfiguration()).Entity<FlightReservation>()
                .HasData(new FlightReservation()
                {
                    Id = 1,
                    Description = "Reserva de Voo para Paris",
                    InputDate = DateTime.Now,
                    OutputDate = DateTime.Now.AddDays(10),
                    FlightId = 1,
                });


            modelBuilder.ApplyConfiguration(new CarReservationEntityConfiguration()).Entity<CarReservation>()
                .HasData(new CarReservation()
                {
                    Id = 1,
                    Name = "Dienisson",
                    InputDate = DateTime.Now,
                    OutputDate = DateTime.Now.AddDays(10),
                    CarId = 1,
                });


            modelBuilder.ApplyConfiguration(new HotelReservationEntityConfiguration()).Entity<HotelReservation>()
                .HasData(new HotelReservation()
                {
                    Id = 1,
                    Description = "Reserva de hotel em Paris",
                    InputDate = DateTime.Now,
                    OutputDate = DateTime.Now.AddDays(10),
                    HotelId = 1,
                });

            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration()).Entity<Customer>()
              .HasData(new Customer() { Id = 1, Name = "José", LastName = "Silva", Sex = SexEnum.Male, FlightReservationId = 1 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
