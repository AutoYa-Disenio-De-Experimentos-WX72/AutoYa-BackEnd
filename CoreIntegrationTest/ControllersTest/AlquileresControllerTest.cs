 using AutoMapper;
using AutoYa_Backend.AutoYa.Controllers;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.AutoYa.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Moq;

namespace CoreIntegrationTest.Controllers;

public class AlquileresControllerTest
{

[Fact]
public async Task DeleteAsync_WithValidId_ShouldDeleteAlquiler()
{
    // Arrange
    var mockService = new Mock<IAlquilerService>();
    var mockMapper = new Mock<IMapper>();

    var id = 1;
    var alquiler = new Alquiler { Id = id };
    var alquilerResource = new AlquilerResource { Id = id };

    mockService.Setup(service => service.DeleteAsync(id)).ReturnsAsync(new AlquilerResponse(alquiler));
    mockMapper.Setup(mapper => mapper.Map<Alquiler, AlquilerResource>(alquiler)).Returns(alquilerResource);

    var controller = new AlquileresController(mockService.Object, mockMapper.Object);

    // Act
    var result = await controller.DeleteAsync(id);

    // Assert
    var okObjectResult = Assert.IsType<OkObjectResult>(result);
    var model = Assert.IsType<AlquilerResource>(okObjectResult.Value);
    Assert.Equal(alquiler.Id, model.Id);
}
[Fact]
public async Task PostAsync_WithInvalidModel_ShouldReturnBadRequest()
{
    // Arrange
    var mockService = new Mock<IAlquilerService>();
    var mockMapper = new Mock<IMapper>();

    var controller = new AlquileresController(mockService.Object, mockMapper.Object);
    controller.ModelState.AddModelError("TestError", "TestErrorMessage");

    var saveResource = new SaveAlquilerResource(); // Modelo no válido

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
    var mockService = new Mock<IAlquilerService>();
    var mockMapper = new Mock<IMapper>();

    var controller = new AlquileresController(mockService.Object, mockMapper.Object);
    controller.ModelState.AddModelError("TestError", "TestErrorMessage");

    var saveResource = new SaveAlquilerResource(); // Modelo no válido

    // Act
    var result = await controller.PutAsync(1, saveResource); // Se asume que el ID es 1

    // Assert
    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
    Assert.NotNull(badRequestResult);
    Assert.Equal(400, badRequestResult.StatusCode);
}

[Fact]
public async Task GetAllAsync_ShouldReturnAllAlquileres()
{
    // Arrange
    var mockService = new Mock<IAlquilerService>();
    var mockMapper = new Mock<IMapper>();

    var alquileres = new List<Alquiler>
    {
        new Alquiler { Id = 1 },
        new Alquiler { Id = 2 }
    };

    mockService.Setup(service => service.ListAsync()).ReturnsAsync(alquileres);
    var controller = new AlquileresController(mockService.Object, mockMapper.Object);

    // Act
    var result = await controller.GetAllAsync();

    // Assert
    Assert.NotNull(result);
}


}