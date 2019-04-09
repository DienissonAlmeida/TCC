using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using eFlight.Domain.Features.Reservations;

namespace TestEstrategyTurism.Data.Features.Reservations
{
    public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(key => key.Id);

            //builder.HasOne(p => p.Hotel).WithMany();
            //builder.HasOne(p => p.User).WithMany();
            //builder.HasOne(p => p.Car).WithMany();
        }
    }
}
