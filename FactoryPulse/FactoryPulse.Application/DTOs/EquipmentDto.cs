using FactoryPulse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Application.DTOs
{
    public class EquipmentDto
    {
        public long EquipmentId { get; set; }
        public EquipmentState CurrentState { get; set; }

        public long? RunningOrderId { get; set; }

        public string ChangedBy { get; set; }

        public string ReasonOfStateChange { get; set; }
    }
}
