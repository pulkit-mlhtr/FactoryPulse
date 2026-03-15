using NUnit.Framework;
using Moq;
using FactoryPulse.API.Controller;
using FactoryPulse.Application.Services;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Domain.Entities;
using FactoryPulse.API.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using FactoryPulse.Application.Interface;

namespace FactoryPulse.API.Tests
{
    public class EquipmentControllerTests
    {
        private EquipmentController _controller;
        private Mock<IEquipmentService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IEquipmentService>();
            _controller = new EquipmentController(_serviceMock.Object);
        }

        [Test]
        public async Task GetEquipments_ReturnsOkWithList()
        {
            var equipment = new Equipment(1, "type", 1, 2, "PLC");
            var prop = typeof(Equipment).GetProperty("EquipmentId");
            var setMethod = prop.GetSetMethod(true);
            setMethod.Invoke(equipment, new object[] { 1L });

            var list = new List<Equipment> { equipment };

            var serviceMock = new Mock<IEquipmentService>();
            serviceMock.Setup(s => s.GetEquipmentsAsync(101,null)).ReturnsAsync(list);

            _controller = new EquipmentController(serviceMock.Object);

            var result = await _controller.GetEquipments(101,null) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var returned = result.Value as IList<Equipment>;
            Assert.IsNotNull(returned);
            Assert.AreEqual(1, returned.Count);
        }

        [Test]
        public async Task UpdateState_WithValidRequest_ReturnsOk()
        {
            var request = new UpdateEquipmentStateRequest
            {
                EquipmentId = 1,
                CurrentState = FactoryPulse.Domain.Enums.EquipmentState.Green,
                ChangedBy = "tester",
                ReasonOfStateChange = "reason"
            };

            var serviceMock = new Mock<IEquipmentService>();
            serviceMock.Setup(s => s.UpdateEquipmentStateAsync(It.IsAny<EquipmentDto>())).Returns(Task.CompletedTask);

            _controller = new EquipmentController(serviceMock.Object);

            var result = await _controller.UpdateState(request) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task UpdateState_WithInvalidRequest_ReturnsBadRequest()
        {
            var result = await _controller.UpdateState(null) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
