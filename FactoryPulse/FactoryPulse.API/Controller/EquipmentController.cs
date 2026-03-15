using FactoryPulse.API.Request;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Services;
using FactoryPulse.Application.Services.Interface;
using FactoryPulse.Domain.Enums;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateState(
            [FromBody] UpdateEquipmentStateRequest request)
        {
            if (request == null || request.EquipmentId == 0)
                return BadRequest("Invalid equipment data");


            await _service.UpdateEquipmentStateAsync(new EquipmentDto
            {
                EquipmentId = request.EquipmentId,
                CurrentState = request.CurrentState,
                RunningOrderId = request.RunningOrderId,
                ChangedBy = request.ChangedBy,
                ReasonOfStateChange = request.ReasonOfStateChange
            });

            return Ok(new { Message = "Equipment state updated successfully" });
        }
    }
}
