using FactoryPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FactoryPulse.Domain.Interface
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetAsync(Expression<Func<Equipment, bool>> filter);

        Task UpdateAsync(Equipment equipment);
    }
}
