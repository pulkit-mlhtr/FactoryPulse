using FactoryPulse.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.API.Controller
{
    [ApiController]
    [Route("api/factory")]
    public class FactoryController : ControllerBase
    {
        private readonly IFactoryService _service;

        public FactoryController(IFactoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetFactoriesAsync());
        }
    }
}
