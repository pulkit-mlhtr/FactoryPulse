using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Configuration
{
    internal class EquipmentStateHistoryConfiguration : IEntityTypeConfiguration<EquipmentStateHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentStateHistory> builder)
        {
            builder.ToTable("equipment_state_histories");
            builder.HasKey(h => h.LogId);
            builder.Property(h => h.ChangedBy).IsRequired().HasMaxLength(100);
            builder.Property(h => h.EquipmentId).IsRequired();
            builder.Property(x => x.PreviousState)
               .IsRequired();
            builder.Property(x => x.NewState)
                .IsRequired();

            builder.HasOne(h => h.Equipment)
                   .WithMany(e => e.StateHistories)
                   .HasForeignKey(h => h.EquipmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
