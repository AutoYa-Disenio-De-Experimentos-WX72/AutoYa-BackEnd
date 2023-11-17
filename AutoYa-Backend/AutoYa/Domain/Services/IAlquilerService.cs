using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IAlquilerService
{
    Task<IEnumerable<Alquiler>> ListAsync();
    Task<IEnumerable<Alquiler>> ListByVehiculoIdAsync(int vehiculoId);
    Task<IEnumerable<Alquiler>> ListByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Alquiler>> ListByArrendatarioIdAsync(int arrendatarioId);
    Task<AlquilerResponse> SaveAsync(Alquiler alquiler);
    Task<AlquilerResponse> UpdateAsync(int alquilerId, Alquiler alquiler);
    Task<AlquilerResponse> DeleteAsync(int alquilerId);
}