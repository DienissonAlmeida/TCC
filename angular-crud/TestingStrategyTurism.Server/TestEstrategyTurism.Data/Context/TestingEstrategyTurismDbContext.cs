using Microsoft.EntityFrameworkCore;
using TestEstrategyTurism.Data.Features.Hotels;
using TestEstrategyTurism.Domain.Features.Hotels;
using TestEstrategyTurism.Domain.Features.Cars;

namespace TestEstrategyTurism.Data.Context
{
    public class TestingEstrategyTurismDbContext : DbContext
    {
        public TestingEstrategyTurismDbContext(DbContextOptions<TestingEstrategyTurismDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Car> Cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelEntityConfiguration()).Entity<Hotel>()
                .HasData(
                    new Hotel { Id = 1, Name = "San Bernardo", City = "Vacaria", Stars = 4},
                    new Hotel { Id = 2, Name = "Lages Plaza Hotel", City = "Lages", Stars = 4 }
                    );
            modelBuilder.ApplyConfiguration(new CarEntityConfiguration()).Entity<Car>()
                .HasData(
                    new Car {Id = 1, Model = "C4", Brand = "Citroen", AirConditioning = true, Passengers = 5, Transmission = Transmission.Manual}
                    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
