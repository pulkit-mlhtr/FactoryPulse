using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class ProductionLine
    {
        public int ProductionLineId { get; private set; }

        public string LineCode { get; private set; }

        public int FactoryId { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public Factory Factory { get; private set; } = null!;

        public ICollection<Equipment> Equipments { get; private set; } = new List<Equipment>();

        private ProductionLine() { }

        public ProductionLine(string lineCode, int factoryId)
        {
            LineCode = lineCode;
            FactoryId = factoryId;
        }
    }
}
