using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).ValueGeneratedNever(); 
            builder.HasOne(o => o.Equipment)
                   .WithMany(e=>e.ScheduledOrders)
                   .HasForeignKey(o => o.EquipmentId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
