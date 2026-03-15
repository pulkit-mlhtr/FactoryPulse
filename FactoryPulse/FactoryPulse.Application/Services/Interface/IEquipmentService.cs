using FactoryPulse.Application.DTOs;
using FactoryPulse.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FactoryPulse.Application.Services.Interface
{
    public interface IEquipmentService
    {
        Task AddEquipmentsAsync(IList<Equipment> equipments);

        Task<IList<Equipment>> GetEquipmentsAsync(int factoryId, int? productionLine);

        Task UpdateEquipmentStateAsync(EquipmentDto equipment);

    }
}
