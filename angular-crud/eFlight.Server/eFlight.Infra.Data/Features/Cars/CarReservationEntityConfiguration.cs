using eFlight.Domain.Features.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eFlight.Infra.Data.Features.Cars
{
    public class CarReservationEntityConfiguration : IEntityTypeConfiguration<CarReservation>
    {
        public void Configure(EntityTypeBuilder<CarReservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.InputDate);
            builder.Property(x => x.OutputDate);


        }
    }
}
