using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Context;
using FactoryPulse.Infrastructure.Repository.Interface;

namespace FactoryPulse.Infrastructure.Repository
{
    public class EquipmentRepository(AppDbContext context) : IEquipmentRepository
    {       
        public async Task<List<Equipment>> GetAllAsync()
        {
            return await context.Equipments.ToListAsync();
        }

        public async Task<Equipment?> GetByIdAsync(string id)
        {
            return await context.Equipments
                .FirstOrDefaultAsync(x => x.EquipmentId == id);
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            context.Equipments.Update(equipment);
            await context.SaveChangesAsync();
        }
    }
}
