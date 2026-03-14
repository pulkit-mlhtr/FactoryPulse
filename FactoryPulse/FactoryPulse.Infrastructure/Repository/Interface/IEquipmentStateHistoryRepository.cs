using FactoryPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Repository.Interface
{
    public interface IEquipmentStateHistoryRepository
    {
        Task AddAsync(EquipmentStateHistory log);
    }
}
