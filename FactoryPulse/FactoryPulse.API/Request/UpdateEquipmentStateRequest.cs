using FactoryPulse.Application.DTOs;
using FactoryPulse.Domain.Enums;

namespace FactoryPulse.API.Request
{
    public class UpdateEquipmentStateRequest
    {
        public long EquipmentId { get; set; }
        public EquipmentState CurrentState { get; set; }

        public long? RunningOrderId { get; set; }

        public string ChangedBy { get; set; }

        public string ReasonOfStateChange { get; set; }
    }
}
