using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class EquipmentStateLog(
        string equipmentId,
        EquipmentState previousState,
        EquipmentState newState,
        Guid changedByUserId,
        Guid? orderId)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string EquipmentId { get; private set; } = equipmentId;

        public EquipmentState PreviousState { get; private set; } = previousState;

        public EquipmentState NewState { get; private set; } = newState;

        public Guid ChangedByUserId { get; private set; } = changedByUserId;

        public Guid? OrderId { get; private set; } = orderId;

        public DateTime ChangedAt { get; private set; } = DateTime.UtcNow;
    }
}
