using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestEstrategyTurism.Domain.Features.Users;

namespace TestEstrategyTurism.Data.Features.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            //builder.HasMany(b => b.Reservations).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
