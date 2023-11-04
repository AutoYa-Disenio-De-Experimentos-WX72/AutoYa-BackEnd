using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IVehiculoRepository
{
    Task<IEnumerable<Vehiculo>> ListAsync();
    Task AddAsync(Vehiculo vehiculo);
    Task<Vehiculo> FindByIdAsync(int vehiculoId);
    void Update(Vehiculo vehiculo);
    void Remove(Vehiculo vehiculo);
    Task<IEnumerable<Vehiculo>> FindByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Vehiculo>> FindByArrendatarioIdAsync(int arrendatarioId);
    Task<IEnumerable<Vehiculo>> FindByAlquilerIdAsync(int alquilerId);
}