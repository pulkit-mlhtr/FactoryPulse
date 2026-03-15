using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FactoryPulse.Application.Services
{
    public class EquipmentService(IEquipmentRepository equipmentRepository, IEquipmentNotifier notifier) : IEquipmentService
    {
        public Task AddEquipmentsAsync(IList<Equipment> equipments)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Equipment>> GetEquipmentsAsync(int factoryId, int? productionLine)
        {
            return await equipmentRepository
                .GetAsync(e => e.FactoryId == factoryId && ((productionLine == null) || e.ProductionLineId == productionLine));
        }

        public async Task UpdateEquipmentStateAsync(EquipmentDto equipment)
        {
            List<Equipment>? toUpdateEquipment = await equipmentRepository
                .GetAsync(x => x.EquipmentId == equipment.EquipmentId);

            if (toUpdateEquipment == null || toUpdateEquipment.Count == 0)
                throw new KeyNotFoundException("Equipment not found");

            // Domain method handles validation
            toUpdateEquipment[0]
                .UpdateState(equipment.CurrentState, equipment.RunningOrderId, 
                             equipment.ChangedBy, equipment.ReasonOfStateChange);

            // Save changes
            await equipmentRepository.UpdateAsync(toUpdateEquipment[0]);

            // Publish event for UI
            await notifier.BroadcastStateChange(equipment);
        }
    }
}
