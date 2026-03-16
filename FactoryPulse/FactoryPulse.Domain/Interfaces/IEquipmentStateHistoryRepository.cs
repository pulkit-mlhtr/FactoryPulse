using FactoryPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Interfaces
{
    public interface IEquipmentStateHistoryRepository
    {
        Task AddAsync(IEnumerable<EquipmentStateHistory> logs);
        Task<IList<EquipmentStateHistory>> GetByEquipmentIdAsync(long equipmentId);
    }
}
