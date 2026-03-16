using FactoryPulse.API.Hubs;
using FactoryPulse.API.Request;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FactoryPulse.API.Controller
{
    [ApiController]
    [Route("api/equipments")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;
        private readonly IHubContext<EquipmentHub> _hub;

        public EquipmentController(IEquipmentService service,
       IHubContext<EquipmentHub> hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpGet("{factoryId}")]
        public async Task<IActionResult> GetEquipments([FromRoute] int factoryId)
        {
            if(factoryId == 0)
            {
                throw new BadHttpRequestException("Invalid input");
            }
            var equipments = await _service.GetEquipmentsAsync(factoryId);
            return Ok(equipments);
        }

        [HttpGet("{equipmentId}/state-history")]
        public async Task<IActionResult> GetStateHistories(int equipmentId)
        {
            if (equipmentId == 0)
            {
                throw new BadHttpRequestException("Invalid input");
            }
            var equipments = await _service.GetEquipmentStateHistoriesAsync(equipmentId);
            return Ok(equipments);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateState(
            [FromBody] UpdateEquipmentStateRequest request)
        {                
            if(request == null)
            {
                return BadRequest("Request body cannot be null");
            }

            var toBeUpdated = new EquipmentDto
            {
                EquipmentId = request.EquipmentId,
                ProductionLine = request.ProductionLine,
                CurrentState = request.CurrentState,
                RunningOrderId = request.RunningOrderId,
                ChangedBy = request.ChangedBy,
                ReasonOfStateChange = request.ReasonOfStateChange
            };
            await _service.UpdateEquipmentStateAsync(toBeUpdated);

            await _hub.Clients.All.SendAsync(
            "equipmentStateUpdated",
            toBeUpdated);

            return Ok(request);
        }
    }
}
