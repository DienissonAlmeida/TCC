using Microsoft.EntityFrameworkCore;
using eFlight.Data.Features.Hotels;
using eFlight.Domain.Features.Hotels;
using eFlight.Domain.Features.Cars;
using eFlight.Domain.Features.Reservations;
using eFlight.Domain.Features.Users;
using eFlight.Data.Features.Cars;
using eFlight.Domain.Features.Flights;
using System;

namespace eFlight.Data.Context
{
    public class eFlightDbContext : DbContext
    {
        public eFlightDbContext(DbContextOptions<eFlightDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            CreateRelationships(modelBuilder);
        }

        private static void CreateRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(c => c.Reservations)
                         .WithOne(e => e.User);

            modelBuilder.Entity<Flight>()
            .HasMany(c => c.Reservations)
             .WithOne(e => e.Flight);

            modelBuilder.Entity<Car>()
                 .HasMany(c => c.Reservations)
                    .WithOne(e => e.Car);

            modelBuilder.Entity<Hotel>()
                        .HasMany(c => c.Reservations)
                          .WithOne(e => e.Hotel);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelEntityConfiguration()).Entity<Hotel>()
                .HasData(
                    new Hotel { Id = 1, Name = "Hotel Darcet", City = "Paris", Daily = 397 },
                    new Hotel { Id = 2, Name = "Hôtel La Manufacture", City = "Paris", Daily = 338 },
                    new Hotel { Id = 3, Name = "Hotel Italia", City = "Roma", Daily = 859 },
                    new Hotel { Id = 4, Name = "Best Western Plus Hotel Universo", City = "Roma", Daily = 611 },
                    new Hotel { Id = 5, Name = "Hotel Colosseum", City = "Roma", Daily = 592 },
                    new Hotel { Id = 6, Name = "SIXTY SoHo", City = "Nova Yorque", Daily = 1.058 },
                    new Hotel { Id = 7, Name = "YOTEL New York", City = "Nova Yorque", Daily = 522 },
                    new Hotel { Id = 8, Name = "Hotel Arpoador", City = "Rio de Janeiro", Daily = 533 },
                    new Hotel { Id = 9, Name = "Prodigy Hotel Santos Dumont Airport", City = "Rio de Janeiro", Daily = 338 }
                    );


            modelBuilder.ApplyConfiguration(new CarEntityConfiguration()).Entity<Car>()
                .HasData(
                    new Car { Id = 1, Model = "C4", Brand = "Citroen", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual },
                    new Car { Id = 2, Model = "New Fiesta", Brand = "Ford", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual },
                    new Car { Id = 3, Model = "Onix", Brand = "Chevrolet", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual },
                    new Car { Id = 4, Model = "HB20", Brand = "Hyundai", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual },
                    new Car { Id = 5, Model = "Gol", Brand = "Volkswagen", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual },
                    new Car { Id = 6, Model = "Argo", Brand = "Fiat", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual }
                    );

            modelBuilder.ApplyConfiguration(new CarEntityConfiguration()).Entity<User>()
                .HasData(
                new User { Id = 1, Name = "Dienisson", Cpf = "03198210054" }
                );

            modelBuilder.ApplyConfiguration(new CarEntityConfiguration()).Entity<Flight>()
                .HasData(
                new Flight { Id = 1, Origin = "São Paulo", Destination = "Paris" , Out = DateTime.Now, Return = DateTime.Now.AddDays(10) }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
