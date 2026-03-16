using FactoryPulse.API.Request;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.API.Controller
{
    [ApiController]
    [Route("api/equipments")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipments([FromQuery] int factoryId,[FromQuery] int? productionLineId = null)
        {
            if(factoryId == 0)
            {
                throw new BadHttpRequestException("Invalid input");
            }
            var equipments = await _service.GetEquipmentsAsync(factoryId, productionLineId);
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
            await _service.UpdateEquipmentStateAsync(new EquipmentDto
            {
                EquipmentId = request.EquipmentId,
                ProductionLine = request.ProductionLine,
                CurrentState = request.CurrentState,
                RunningOrderId = request.RunningOrderId,
                ChangedBy = request.ChangedBy,
                ReasonOfStateChange = request.ReasonOfStateChange
            });

            return Ok(new { Message = "Equipment state updated successfully" });
        }
    }
}
