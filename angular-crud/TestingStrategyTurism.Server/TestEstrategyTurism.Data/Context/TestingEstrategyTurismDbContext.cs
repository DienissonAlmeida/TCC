using Microsoft.EntityFrameworkCore;
using TestEstrategyTurism.Data.Features.Hotels;
using TestEstrategyTurism.Domain.Features.Hotels;
using TestEstrategyTurism.Domain.Features.Cars;
using TestEstrategyTurism.Data.Features.Cars;
using TestEstrategyTurism.Domain.Features.Reservations;
using TestEstrategyTurism.Domain.Features.Users;

namespace TestEstrategyTurism.Data.Context
{
    public class TestingEstrategyTurismDbContext : DbContext
    {
        public TestingEstrategyTurismDbContext(DbContextOptions<TestingEstrategyTurismDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            modelBuilder.Entity<User>()
                        .HasMany(c => c.Reservations)
                         .WithOne(e => e.User);
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
