using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.OrderId);                   
            
            builder.HasIndex(o => o.OrderId)
                .IsUnique();

            builder.Property(o => o.EquipmentId)
                .IsRequired(false);

            builder.Property(o => o.StartTime)
                .IsRequired();  

            builder.Property(o => o.EndTime)
                .IsRequired(false);

            builder.Property(o => o.Status)
                .IsRequired();  

            builder.HasOne(o => o.Equipment)
                .WithMany()
                .HasForeignKey(o => o.EquipmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
