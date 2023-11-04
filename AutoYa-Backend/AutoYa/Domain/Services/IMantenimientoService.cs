using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IMantenimientoService
{
    Task<IEnumerable<Mantenimiento>> ListAsync();
    Task<IEnumerable<Mantenimiento>> ListByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Mantenimiento>> ListByArrendatarioIdAsync(int arrendatarioId);
    Task<MantenimientoResponse> SaveAsync(Mantenimiento mantenimiento);
    Task<MantenimientoResponse> UpdateAsync(int mantenimientoId, Mantenimiento mantenimiento);
    Task<MantenimientoResponse> DeleteAsync(int mantenimientoId);
}