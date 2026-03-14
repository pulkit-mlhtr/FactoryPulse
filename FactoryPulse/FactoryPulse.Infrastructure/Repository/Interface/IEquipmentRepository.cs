using FactoryPulse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Repository.Interface
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetAllAsync();

        Task<Equipment?> GetByIdAsync(Guid id);

        Task UpdateAsync(Equipment equipment);
    }
}
