using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; private set; }
        public string CountryCode { get; private set; }
        public ICollection<Factory> Factories { get; set; } = [];

        private Country() { }

        public Country(int countryId, string countryCode)
        {
            CountryId = countryId;
            CountryCode = countryCode;
        }
    }
}
