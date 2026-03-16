using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Interfaces;
using FactoryPulse.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Repository
{
    public class EquipmentStateHistoryRepository(AppDbContext context) : IEquipmentStateHistoryRepository
    {
        public async Task AddAsync(IEnumerable<EquipmentStateHistory> logs)
        {
            foreach (var log in logs)
            {
                await context.EquipmentStateHistories.AddAsync(log);
            } 
            await context.SaveChangesAsync();
        }

        public async Task<IList<EquipmentStateHistory>> GetByEquipmentIdAsync(long equipmentId)
        {
            return await context.EquipmentStateHistories
                .Where(x => x.EquipmentId == equipmentId).ToListAsync();
        }        
    }
}
