using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Domain.Interfaces;
using FactoryPulse.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Repository
{
    public class FactoryRepository(AppDbContext context) : IFactoryRepository
    {
        public async Task<IList<Factory>> GetFactoriesAsync()
        {
            return await context.Factories.ToListAsync();
        }
    }
}
