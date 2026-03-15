using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Configuration
{
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder.ToTable("factories");
            builder.HasKey(f => f.FactoryId);
            builder.Property(f => f.FactoryCode).IsRequired().HasMaxLength(50);

            builder.HasOne(f => f.Country)
                   .WithMany(c => c.Factories)
                   .HasForeignKey(f => f.CountryId);
        }
    }
}
