using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryPulse.Infrastructure.Configuration
{
    internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");

            builder.HasKey(e => e.EquipmentId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Factory)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.ProductionLine)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.CurrentState)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired();

            builder.Property(e => e.CurrentOrderId)
                .IsRequired(false);

            builder.HasMany(e => e.ScheduledOrders)
                .WithOne(o => o.Equipment)
                .HasForeignKey(o => o.EquipmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.StateHistories)
                .WithOne(h => h.Equipment)
                .HasForeignKey(h => h.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.EquipmentId)
                .IsUnique();
        }
    }
}
