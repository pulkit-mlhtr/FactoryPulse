using FactoryPulse.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Application.Interface
{
    public interface IFactoryService
    {
        Task<IList<FactoryDto>> GetFactoriesAsync(int countryId);
    }
}
