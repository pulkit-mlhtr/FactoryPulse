using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Context;
using FactoryPulse.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Repository
{
    public class EquipmentStateHistoryRepository(AppDbContext context) : IEquipmentStateHistoryRepository
    {
        public async Task AddAsync(EquipmentStateHistory log)
        {
            await context.EquipmentStateHistories.AddAsync(log);
            await context.SaveChangesAsync();
        }
    }
}
