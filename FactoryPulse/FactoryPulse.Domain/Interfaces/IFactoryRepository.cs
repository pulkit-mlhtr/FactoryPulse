using FactoryPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FactoryPulse.Domain.Interfaces
{
    public interface IFactoryRepository
    {
        Task<IList<Factory>> GetFactoriesAsync(Expression<Func<Factory,bool>> filter);
    }
}
