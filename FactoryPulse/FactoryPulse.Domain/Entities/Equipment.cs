using FactoryPulse.Domain.Enums;
using FactoryPulse.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Equipment(int machineNumber, string name, string factory, string productionLine)
    {
        public string EquipmentId { get; private set; } = StringHelper.Concat(factory,productionLine,name, machineNumber.ToString());

        public string Name { get; private set; } = name;

        public string Factory { get; private set; } = factory;

        public string ProductionLine { get; private set; } = productionLine;

        public EquipmentState CurrentState { get; private set; } = EquipmentState.Red;

        public Guid? CurrentOrderId { get; private set; }

        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public void UpdateState(EquipmentState newState, Guid? orderId)
        {
            CurrentState = newState;
            CurrentOrderId = orderId;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
