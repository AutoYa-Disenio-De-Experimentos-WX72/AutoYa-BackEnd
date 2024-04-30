using AutoMapper;
using AutoYa_Backend.AutoYa.Controllers;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.AutoYa.Resources;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoreIntegrationTest.Controllers;

public class VehiculosControllerTest
{
        [Fact]
        public async Task DeleteAsync_WithValidId_ShouldDeleteVehiculo()
        {
            // Arrange
            var mockService = new Mock<IVehiculoService>();
            var mockMapper = new Mock<IMapper>();

            var id = 1;
            var vehiculo = new Vehiculo { Id = id };
            var vehiculoResource = new VehiculoResource { Id = id };

            mockService.Setup(service => service.DeleteAsync(id)).ReturnsAsync(new VehiculoResponse(vehiculo));
            mockMapper.Setup(mapper => mapper.Map<Vehiculo, VehiculoResource>(vehiculo)).Returns(vehiculoResource);

            var controller = new VehiculosController(mockService.Object, mockMapper.Object);

            // Act
            var result = await controller.DeleteAsync(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<VehiculoResource>(okObjectResult.Value);
            Assert.Equal(vehiculo.Id, model.Id);
        }

        [Fact]
        public async Task PostAsync_WithInvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var mockService = new Mock<IVehiculoService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new VehiculosController(mockService.Object, mockMapper.Object);
            controller.ModelState.AddModelError("TestError", "TestErrorMessage");

            var saveResource = new SaveVehiculoResource(); // Modelo no válido

            // Act
            var result = await controller.PostAsync(saveResource);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task PutAsync_WithInvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var mockService = new Mock<IVehiculoService>();
            var mockMapper = new Mock<IMapper>();

            var controller = new VehiculosController(mockService.Object, mockMapper.Object);
            controller.ModelState.AddModelError("TestError", "TestErrorMessage");

            var saveResource = new SaveVehiculoResource(); // Modelo no válido

            // Act
            var result = await controller.PutAsync(1, saveResource); // Se asume que el ID es 1

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllVehiculos()
        {
            // Arrange
            var mockService = new Mock<IVehiculoService>();
            var mockMapper = new Mock<IMapper>();

            var vehiculos = new List<Vehiculo>
            {
                new Vehiculo { Id = 1 },
                new Vehiculo { Id = 2 }
            };

            mockService.Setup(service => service.ListAsync()).ReturnsAsync(vehiculos);
            var controller = new VehiculosController(mockService.Object, mockMapper.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.NotNull(result);
        }
}