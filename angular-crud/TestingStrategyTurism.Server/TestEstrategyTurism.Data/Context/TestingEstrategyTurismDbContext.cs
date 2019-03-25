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
            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
