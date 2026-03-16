using FactoryPulse.API.Controller;
using FactoryPulse.API.Request;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using FactoryPulse.Application.Services;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Enums;
using FactoryPulse.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace FactoryPulse.API.Tests
{
    [TestFixture]
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
        public void GetEquipments_WithFactoryIdZero_ThrowsBadHttpRequestException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<BadHttpRequestException>(async () =>
                await _controller.GetEquipments(0));

            Assert.AreEqual("Invalid input", ex.Message);
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
            serviceMock.Setup(s => s.GetEquipmentsAsync(101)).ReturnsAsync(list);

            _controller = new EquipmentController(serviceMock.Object);

            var result = await _controller.GetEquipments(101) as OkObjectResult;

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
                ProductionLine = 5,
                CurrentState = FactoryPulse.Domain.Enums.EquipmentState.Green,
                ChangedBy = "tester",
                RunningOrderId = 123,
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

        [Test]
        public async Task GetStateHistories_ReturnsOkWithList()
        {
            // Arrange
            int equipmentId = 1;
            var histories = new List<EquipmentStateHistory>
            {
                new(
                    equipmentId,
                    EquipmentState.Red,
                    EquipmentState.Green,
                    "tester",
                    123,
                    "message")
            };

            _serviceMock.Setup(s => s.GetEquipmentStateHistoriesAsync(equipmentId))
                .ReturnsAsync(histories);

            // Act
            var result = await _controller.GetStateHistories(equipmentId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var returned = result.Value as List<EquipmentStateHistory>;
            Assert.AreEqual(1, returned.Count);
        }

        [Test]
        public void GetStateHistories_WithEquipmentIdZero_ThrowsBadHttpRequestException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<BadHttpRequestException>(async () =>
                await _controller.GetStateHistories(0));

            Assert.AreEqual("Invalid input", ex.Message);
        }
    }
}
