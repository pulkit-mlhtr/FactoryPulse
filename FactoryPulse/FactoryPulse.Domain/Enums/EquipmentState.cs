using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Enums
{
    public enum EquipmentState
    {
        Red = 1,      // Standing still
        Yellow = 2,   // Starting / winding down
        Green = 3     // Producing normally
    }
}
