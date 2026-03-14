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
            builder.ToTable("EquipmentStateHistories");
            builder.HasKey(x=>x.LogId);

            builder.Property(x => x.PreviousState)
                .IsRequired();

            builder.Property(x => x.NewState)
                .IsRequired();

            builder.Property(x => x.ChangedByUserId)
                .IsRequired();

            builder.Property(x => x.ChangedAt)
                .IsRequired();  

            builder.HasOne(x => x.Equipment)
                .WithMany(e => e.StateHistories)
                .HasForeignKey(x => x.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.LogId);

            builder.Property(x => x.EquipmentId)
                .IsRequired();                


        }
    }
}
