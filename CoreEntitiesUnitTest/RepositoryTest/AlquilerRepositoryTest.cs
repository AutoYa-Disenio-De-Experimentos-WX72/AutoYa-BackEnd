using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Persistence.Repositories;
using AutoYa_Backend.AutoYa.Services;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CoreEntitiesUnitTest.RepositoryTest;

public class AlquilerRepositoryTest
{
        [Fact]
        public async Task AddAsync_ShouldAddAlquilerToContext()
        {
            // Arrange
            var alquiler = new Alquiler { Id = 1 };

            var mockDbSet = new Mock<DbSet<Alquiler>>();
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Alquileres).Returns(mockDbSet.Object);

            var repository = new AlquilerRepository(mockContext.Object);

            // Act
            await repository.AddAsync(alquiler);

            // Assert
            mockDbSet.Verify(m => m.AddAsync(alquiler,default), Times.Once);
        }

        [Fact]
        public async Task FindByIdAsync_WithValidId_ShouldReturnAlquiler()
        {
            // Arrange
            int alquilerIdToFind = 1;
            var expectedAlquiler = new Alquiler { Id = alquilerIdToFind };
    
            var mockDbSet = new Mock<DbSet<Alquiler>>();
            mockDbSet.Setup(m => m.FindAsync(alquilerIdToFind)).ReturnsAsync(expectedAlquiler);

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Alquileres).Returns(mockDbSet.Object);

            var repository = new AlquilerRepository(mockContext.Object);

            // Act
            var result = await repository.FindByIdAsync(alquilerIdToFind);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(alquilerIdToFind, result.Id);
        }
        
        [Fact]
        public void Update_ShouldUpdateAlquilerInContext()
        {
            // Arrange
            var alquiler = new Alquiler { Id = 1, Estado = "Activo" };

            var mockDbSet = new Mock<DbSet<Alquiler>>();

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Alquileres).Returns(mockDbSet.Object);

            var repository = new AlquilerRepository(mockContext.Object);

            // Act
            repository.Update(alquiler);

            // Assert
            mockDbSet.Verify(m => m.Update(alquiler), Times.Once);
        }
        
        [Fact]
        public void Remove_ShouldRemoveAlquilerFromContext()
        {
            // Arrange
            var alquiler = new Alquiler { Id = 1 };

            var mockDbSet = new Mock<DbSet<Alquiler>>();

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Alquileres).Returns(mockDbSet.Object);

            var repository = new AlquilerRepository(mockContext.Object);

            // Act
            repository.Remove(alquiler);

            // Assert
            mockDbSet.Verify(m => m.Remove(alquiler), Times.Once);
        }



}