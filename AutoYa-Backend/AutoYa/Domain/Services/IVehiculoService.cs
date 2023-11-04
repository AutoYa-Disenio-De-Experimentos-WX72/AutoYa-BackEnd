using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IVehiculoService
{
    Task<IEnumerable<Vehiculo>> ListAsync();
    Task<IEnumerable<Vehiculo>> ListByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Vehiculo>> ListByArrendatarioIdAsync(int arrendatarioId);
    Task<IEnumerable<Vehiculo>> ListByAlquilerIdAsync(int alquilerId);
    Task<VehiculoResponse> SaveAsync(Vehiculo vehiculo);
    Task<VehiculoResponse> UpdateAsync(int vehiculoId, Vehiculo vehiculo);
    Task<VehiculoResponse> DeleteAsync(int vehiculoId);
}