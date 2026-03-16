using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Domain.Interfaces;
using FactoryPulse.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FactoryPulse.Infrastructure.Repository
{
    public class FactoryRepository(AppDbContext context) : IFactoryRepository
    {
        public async Task<IList<Factory>> GetFactoriesAsync(Expression<Func<Factory, bool>> filter)
        {
            return await context.Factories.Where(filter).ToListAsync();
        }
    }
}
