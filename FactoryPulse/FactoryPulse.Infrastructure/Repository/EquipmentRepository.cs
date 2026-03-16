using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FactoryPulse.Infrastructure.Repository
{
    public class EquipmentRepository(AppDbContext context) : IEquipmentRepository
    {       
        public async Task<List<Equipment>> GetAsync(Expression<Func<Equipment,bool>> filter)
        {
            return await context.Equipments
                .Where(filter)
                .OrderBy(o=>o.EquipmentId).ToListAsync();
        }      

        public async Task UpdateAsync(Equipment equipment)
        {
            context.Equipments.Update(equipment);
            await context.SaveChangesAsync();
        }
    }
}
