using FactoryPulse.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Application.Interface
{
    public interface IEquipmentNotifier
    {
        Task BroadcastStateChange(EquipmentDto equipment);
    }
}
