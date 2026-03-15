using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Configuration
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("countries");
            builder.HasKey(c => c.CountryId);
            builder.Property(c => c.CountryId).ValueGeneratedNever();
            builder.Property(c => c.CountryCode).IsRequired().HasMaxLength(10);
        }
    }
}
