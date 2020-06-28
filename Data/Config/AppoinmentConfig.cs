using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Config
{
    public class AppoinmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Passengers)
                .WithOne(x => x.Appointment)
                .HasForeignKey(x => x.AppoinmentId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
