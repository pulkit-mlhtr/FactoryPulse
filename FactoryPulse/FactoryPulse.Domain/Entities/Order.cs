using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Order(long orderNumber, string equipmentId)
    {
        public long OrderId { get; private set; } = orderNumber;

        public string EquipmentId { get; private set; } = equipmentId;

        public DateTime StartTime { get; private set; } = DateTime.UtcNow;

        public DateTime? EndTime { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Scheduled;

        public Equipment Equipment { get; set; } = null!;
        public void Complete()
        {
            Status = OrderStatus.Completed;
            EndTime = DateTime.UtcNow;
        }
    }
}
