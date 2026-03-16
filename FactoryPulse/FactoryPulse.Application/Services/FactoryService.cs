using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using FactoryPulse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Application.Services
{
    public class FactoryService(IFactoryRepository factoryRepository) : IFactoryService
    {
        public async Task<IList<FactoryDto>> GetFactoriesAsync(int countryId)
        {
            var response = await factoryRepository.GetFactoriesAsync(x=> (countryId <= 0) || x.CountryId == countryId);
            return [.. response.Select(f => new FactoryDto
            {
                FactoryId = f.FactoryId,
                FactoryCode = f.FactoryCode,
            })];
        }
    }
}
