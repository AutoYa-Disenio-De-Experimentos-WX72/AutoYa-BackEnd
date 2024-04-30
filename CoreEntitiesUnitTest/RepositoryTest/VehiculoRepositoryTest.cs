using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Persistence.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CoreEntitiesUnitTest.RepositoryTest;

public class VehiculoRepositoryTest
{
    [Fact]
        public async Task AddAsync_ShouldAddVehiculoToContext()
        {
            // Arrange
            var vehiculo = new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla" };

            var mockDbSet = new Mock<DbSet<Vehiculo>>();
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Vehiculos).Returns(mockDbSet.Object);

            var repository = new VehiculoRepository(mockContext.Object);

            // Act
            await repository.AddAsync(vehiculo);

            // Assert
            mockDbSet.Verify(m => m.AddAsync(vehiculo, default), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateVehiculoInContext()
        {
            // Arrange
            var vehiculo = new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla" };

            var mockDbSet = new Mock<DbSet<Vehiculo>>();
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Vehiculos).Returns(mockDbSet.Object);

            var repository = new VehiculoRepository(mockContext.Object);

            // Act
            repository.Update(vehiculo);

            // Assert
            mockDbSet.Verify(m => m.Update(vehiculo), Times.Once());
        }

        [Fact]
        public async Task FindByIdAsync_ShouldReturnVehiculo()
        {
            // Arrange
            var vehiculo = new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla" };

            var mockDbSet = new Mock<DbSet<Vehiculo>>();
            mockDbSet.Setup(m => m.FindAsync(It.IsAny<int>())).ReturnsAsync(vehiculo);

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Vehiculos).Returns(mockDbSet.Object);

            var repository = new VehiculoRepository(mockContext.Object);

            // Act
            var result = await repository.FindByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Remove_ShouldRemoveVehiculoFromContext()
        {
            // Arrange
            var vehiculo = new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla" };

            var mockDbSet = new Mock<DbSet<Vehiculo>>();
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Vehiculos).Returns(mockDbSet.Object);

            var repository = new VehiculoRepository(mockContext.Object);

            // Act
            repository.Remove(vehiculo);

            // Assert
            mockDbSet.Verify(m => m.Remove(vehiculo), Times.Once());
        }
}