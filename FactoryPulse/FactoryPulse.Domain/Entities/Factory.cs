using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Factory(int factoryId, string factoryCode, int countryId)
    {
        public int FactoryId { get; private set; } = factoryId;
        public string FactoryCode { get; private set; } = factoryCode;  

        public int CountryId { get; private set; } = countryId; 

        public Country Country { get; set; } = null!;
    }
}
