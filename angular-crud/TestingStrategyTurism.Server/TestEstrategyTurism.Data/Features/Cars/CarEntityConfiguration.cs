using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEstrategyTurism.Domain.Features.Cars;

namespace TestEstrategyTurism.Data.Features.Cars
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Model).HasMaxLength(50);
            builder.Property(p => p.Brand).HasMaxLength(50);
            builder.Property(p => p.Passengers).HasMaxLength(10);
            builder.Property(p => p.Photos);
            builder.Property(p => p.Transmission).HasMaxLength(10);
            builder.Property(p => p.AirConditioning);
        }
    }
}
