using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Configuration
{
    public class ProductionLineConfiguration : IEntityTypeConfiguration<ProductionLine>
    {
        public void Configure(EntityTypeBuilder<ProductionLine> builder)
        {
            builder.ToTable("production_lines");
            builder.HasKey(p => p.ProductionLineId);
            builder.Property(p => p.LineCode).IsRequired().HasMaxLength(50);

            builder.HasOne(p => p.Factory)
                   .WithMany() // Assuming no nav prop on Factory
                   .HasForeignKey(p => p.FactoryId);
        }
    }
}
