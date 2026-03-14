using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Order(string orderNumber, Guid equipmentId)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string OrderNumber { get; private set; } = orderNumber;

        public Guid EquipmentId { get; private set; } = equipmentId;

        public DateTime StartTime { get; private set; } = DateTime.UtcNow;

        public DateTime? EndTime { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Scheduled;

        public void Complete()
        {
            Status = OrderStatus.Completed;
            EndTime = DateTime.UtcNow;
        }
    }
}
