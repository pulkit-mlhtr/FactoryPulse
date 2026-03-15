using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Order
    {
        public long OrderId { get; private set; }

        public long EquipmentId { get; private set; }

        public int Quantity { get; private set; }

        public DateTime StartTime { get; private set; } = DateTime.UtcNow;

        public DateTime? EndTime { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Scheduled;

        public Equipment Equipment { get; set; } = null!;
        public void Complete()
        {
            Status = OrderStatus.Completed;
            EndTime = DateTime.UtcNow;
        }

        private Order() { }

        public Order(long orderNumber, long equipmentId, int quantity)
        {
           OrderId = orderNumber;  
            EquipmentId = equipmentId;
            Quantity = quantity;
        }
    }
}
