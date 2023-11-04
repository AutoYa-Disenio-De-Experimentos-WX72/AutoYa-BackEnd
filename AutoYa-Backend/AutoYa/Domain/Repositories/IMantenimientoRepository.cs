using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IMantenimientoRepository
{
    Task<IEnumerable<Mantenimiento>> ListAsync();
    Task AddAsync(Mantenimiento mantenimiento);
    Task<Mantenimiento> FindByIdAsync(int mantenimientoId);
    void Update(Mantenimiento mantenimiento);
    void Remove(Mantenimiento mantenimiento);
    Task<IEnumerable<Mantenimiento>> FindByArrendatarioIdAsync(int arrendatarioId);
    Task<IEnumerable<Mantenimiento>> FindByPropietarioIdAsync(int propietarioId);

}