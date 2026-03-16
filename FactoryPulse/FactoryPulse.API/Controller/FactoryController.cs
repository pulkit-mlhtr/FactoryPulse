using FactoryPulse.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactoryController : ControllerBase
    {
        private readonly IFactoryService _service;

        public FactoryController(IFactoryService service)
        {
            _service = service;
        }
        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get(int countryId)
        {
            return Ok(await _service.GetFactoriesAsync(countryId));
        }
    }
}
