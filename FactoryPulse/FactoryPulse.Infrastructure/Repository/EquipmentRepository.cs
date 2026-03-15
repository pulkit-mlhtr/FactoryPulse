using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Context;
using FactoryPulse.Domain.Interface;
using System.Linq.Expressions;

namespace FactoryPulse.Infrastructure.Repository
{
    public class EquipmentRepository(AppDbContext context) : IEquipmentRepository
    {       
        public async Task<List<Equipment>> GetAsync(Expression<Func<Equipment,bool>> filter)
        {
            return await context.Equipments.Where(filter).ToListAsync();
        }       

        public async Task UpdateAsync(Equipment equipment)
        {
            context.Equipments.Update(equipment);
            await context.SaveChangesAsync();
        }
    }
}
