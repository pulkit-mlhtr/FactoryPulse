using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Interfaces;
using FactoryPulse.Infrastructure.Context;

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
