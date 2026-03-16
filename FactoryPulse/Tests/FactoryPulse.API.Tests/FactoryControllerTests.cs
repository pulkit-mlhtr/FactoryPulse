using FactoryPulse.API.Controller;
using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interface;
using FactoryPulse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryPulse.API.Tests
{
    [TestFixture]
    public class FactoryControllerTests
    {
        private FactoryController _controller;
        private Mock<IFactoryService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IFactoryService>();
            _controller = new FactoryController(_serviceMock.Object);
        }

        [Test]
        public async Task Get_ReturnsOkWithFactoryList()
        {
            // Arrange
            int countryId = 1;
            var factories = new List<FactoryDto>
            {
                new() {
                    FactoryId = 1,
                    FactoryCode = "Main Plant" },
                new() {  
                    FactoryId =2, 
                    FactoryCode ="Secondary Plant" }
            };

            _serviceMock.Setup(s => s.GetFactoriesAsync(countryId))
                .ReturnsAsync(factories);

            // Act
            var result = await _controller.Get(countryId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual(2, (result.Value as IList<FactoryDto>).Count);
        }

        [Test]
        public async Task Get_WhenNoFactoriesExist_ReturnsOkWithEmptyList()
        {
            // Arrange
            int countryId = 999; // Assuming this country ID has no factories
            var emptyList = new List<FactoryDto>();
            _serviceMock.Setup(s => s.GetFactoriesAsync(countryId))
                .ReturnsAsync(emptyList);

            // Act
            var result = await _controller.Get(countryId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var returnedFactories = result.Value as IList<FactoryDto>;
            Assert.IsEmpty(returnedFactories);
        }
    }
}