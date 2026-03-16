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

            builder.Property(h => h.LogId)
                .HasColumnName("log_id");

            builder.Property(h => h.ChangedBy)
                .HasColumnName("changed_by")
                .IsRequired().HasMaxLength(100);

            builder.Property(h => h.EquipmentId)
                .HasColumnName("equipment_id")
                .IsRequired();
            builder.Property(x => x.PreviousState)
                .HasColumnName("previous_state")
               .IsRequired();
            builder.Property(x => x.NewState)
                .HasColumnName("new_state")
                .IsRequired();

            builder.Property(h => h.OrderId)
                .HasColumnName("order_id");

            builder.Property(h => h.Message)
                .HasColumnName("message")
                .HasMaxLength(500);

            builder.Property(h => h.ChangedAt)
                .HasColumnName("changed_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(h => h.Equipment)
                   .WithMany(e => e.StateHistories)
                   .HasForeignKey(h => h.EquipmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
