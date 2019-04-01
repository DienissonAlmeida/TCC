using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Data.Features.Reservations
{
    public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(key => key.Id);
        }
    }
}
