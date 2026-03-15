using FactoryPulse.Domain.Enums;
using FactoryPulse.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Equipment
    {        
        public long EquipmentId { get; private set; }

        public int MachineNumber { get; private set; }

        public string MachineType { get; private set; }

        public string EquipmentCode { get; private set; }

        public int FactoryId { get; private set; }

        public int ProductionLineId { get; private set; }

        public EquipmentState CurrentState { get; private set; } = EquipmentState.Red;

        public long? CurrentOrderId { get; private set; }

        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public ICollection<EquipmentStateHistory> StateHistories { get; private set; } = [];

        public ICollection<Order> ScheduledOrders { get; private set; } = new List<Order>();

        public ProductionLine ProductionLine { get; private set; } = null!;

        private Equipment() { } 

        public Equipment(
            int machineNumber,
            string machineType,
            int factoryId,
            int productionLineId,
            string productionLineCode)
        {
            MachineNumber = machineNumber;
            MachineType = machineType;
            FactoryId = factoryId;
            ProductionLineId = productionLineId;

            EquipmentCode = StringHelper.Concat(
                factoryId.ToString(),
                productionLineCode,
                machineType,
                machineNumber.ToString());
        }

        public void UpdateState(EquipmentState newState, long? orderId, string changedBy, string reason = null)
        {
            if (CurrentState == newState)
                return;

            var history = new EquipmentStateHistory(EquipmentId,
                                                    CurrentState,
                                                    newState,
                                                    changedBy,
                                                    orderId,
                                                    reason);

            StateHistories.Add(history);

            CurrentState = newState;
            CurrentOrderId = orderId;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
