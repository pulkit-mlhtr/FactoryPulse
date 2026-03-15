using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class EquipmentStateHistory
    {
        public Guid LogId { get; private set; } = Guid.NewGuid();

        public long EquipmentId { get; private set; }

        public EquipmentState PreviousState { get; private set; }

        public EquipmentState NewState { get; private set; }

        public string ChangedBy { get; private set; }

        public long? OrderId { get; private set; }

        public DateTime ChangedAt { get; private set; } = DateTime.UtcNow;

        public string Message { get; set; }

        public Equipment Equipment { get; set; } = null!;

        private EquipmentStateHistory() { }

        public EquipmentStateHistory(long equipmentId,
        EquipmentState previousState,
        EquipmentState newState,
        string changedBy,
        long? orderId,
        string message)
        {
            EquipmentId = equipmentId;
            PreviousState = previousState;
            NewState = newState;
            ChangedBy = changedBy;
            OrderId = orderId;
            Message = message;
        }
    }
}
