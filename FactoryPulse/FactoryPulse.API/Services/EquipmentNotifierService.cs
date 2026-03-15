using FactoryPulse.API.Hubs;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using Microsoft.AspNetCore.SignalR;

namespace FactoryPulse.API.Services
{
    public class EquipmentNotifierService : IEquipmentNotifier
    {
        private readonly IHubContext<EquipmentHub> _hub;

        public EquipmentNotifierService(IHubContext<EquipmentHub> hub)
        {
            _hub = hub;
        }

        public async Task BroadcastStateChange(EquipmentDto equipment)
        {
            await _hub.Clients
                .Group(equipment.ProductionLine.ToString())
                .SendAsync("equipmentStateUpdated", equipment);
        }
    }
}
