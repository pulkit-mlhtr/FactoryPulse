using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Enums;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FactoryPulse.Application.Services
{
    public class EquipmentService(IEquipmentRepository equipmentRepository, 
        IEquipmentStateHistoryRepository equipmentStateHistoryRepository, 
        IEquipmentNotifier notifier) : IEquipmentService
    {
        public Task AddEquipmentsAsync(IList<Equipment> equipments)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Equipment>> GetEquipmentsAsync(int factoryId)
        {
            return await equipmentRepository
                .GetAsync(e => e.FactoryId == factoryId);
        }

        public async Task<IEnumerable<EquipmentStateHistory>> GetEquipmentStateHistoriesAsync(int equipmentId)
        {
            return await equipmentStateHistoryRepository.GetByEquipmentIdAsync(equipmentId);
        }

        public async Task UpdateEquipmentStateAsync(EquipmentDto equipment)
        {
            List<Equipment>? toUpdateEquipment = await equipmentRepository
                .GetAsync(x => x.EquipmentId == equipment.EquipmentId);

            if (toUpdateEquipment == null || toUpdateEquipment.Count == 0)
                throw new KeyNotFoundException("Equipment not found");

            EquipmentState previousEquipmentState = toUpdateEquipment[0].CurrentState;

            // Domain method handles validation
            toUpdateEquipment[0]
                .UpdateState(equipment.CurrentState, equipment.RunningOrderId, 
                             equipment.ChangedBy, equipment.ReasonOfStateChange);

            // Save changes
            await equipmentRepository.UpdateAsync(toUpdateEquipment[0]);

            //Register state change in history
           await equipmentStateHistoryRepository.AddAsync([new EquipmentStateHistory(toUpdateEquipment[0].EquipmentId,
                                                    previousEquipmentState,
                                                    equipment.CurrentState,
                                                    equipment.ChangedBy,
                                                    equipment.RunningOrderId ?? 0,
                                                    equipment.ReasonOfStateChange)]);

            // Publish event for UI
            await notifier.BroadcastStateChange(equipment);
        }
    }
}
