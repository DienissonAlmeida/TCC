using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eFlight.Domain.Features.Cars;

namespace eFlight.Data.Features.Cars
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Model).HasMaxLength(50);
            builder.Property(p => p.Brand).HasMaxLength(50);
            builder.Property(p => p.Passenger).HasMaxLength(10);
            builder.Property(p => p.Photos);
            builder.Property(p => p.Transmission).HasMaxLength(10);
            builder.Property(p => p.AirConditioning);

            //builder.HasMany(b => b.Reservations).WithOne(x => x.Car).HasForeignKey(x => x.CarId);

        }
    }
}
