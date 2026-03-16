using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryPulse.Infrastructure.Configuration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("equipments");
            builder.HasKey(e => e.EquipmentId);

            builder.Property(e => e.EquipmentId)
                .HasColumnName("equipment_id");

            builder.Property(e => e.EquipmentCode)
                .HasColumnName("equipment_code")
                .IsRequired().HasMaxLength(100);

            builder.Property(e => e.MachineType)
                .HasColumnName("machine_type")
                .IsRequired().HasMaxLength(50);

            builder.Property(e => e.FactoryId)
                .HasColumnName("factory_id");

                builder.Property(e => e.ProductionLineId)
                .HasColumnName("production_line_id");

            builder.Property(e => e.MachineNumber)
                .HasColumnName("machine_number");

            builder.Property(e => e.CurrentState)
                .HasColumnName("current_state")                
                .IsRequired();

            builder.Property(e => e.CurrentOrderId)
                .HasColumnName("current_order_id");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();

            builder.HasOne(e => e.ProductionLine)
                   .WithMany(p => p.Equipments)
                   .HasForeignKey(e => e.ProductionLineId);

            builder.HasMany(e => e.ScheduledOrders)
                   .WithOne(o => o.Equipment)
                   .OnDelete(DeleteBehavior.SetNull)
                   .HasForeignKey(o => o.EquipmentId);

            builder.HasMany(e => e.StateHistories)
           .WithOne(h => h.Equipment)
           .HasForeignKey(h => h.EquipmentId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
