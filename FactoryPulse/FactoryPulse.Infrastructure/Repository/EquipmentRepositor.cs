using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Repository
{
    public class EquipmentRepositor : IEquipmentRepository
    {
        public Task<List<Equipment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Equipment?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}
