using Microsoft.AspNetCore.SignalR;

namespace FactoryPulse.API.Hubs
{
    public class EquipmentHub : Hub
    {
        public async Task SubscribeProductionLine(string productionLine)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, productionLine);
        }

        public async Task UnsubscribeProductionLine(string productionLine)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, productionLine);
        }
    }
}
