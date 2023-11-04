using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IAlquilerRepository
{
    Task<IEnumerable<Alquiler>> ListAsync();
    Task AddAsync(Alquiler alquiler);
    Task<Alquiler> FindByIdAsync(int alquilerId);
    void Update(Alquiler alquiler);
    void Remove(Alquiler alquiler);
    Task<IEnumerable<Alquiler>> FindByVehiculoIdAsync(int vehiculoId);
    Task<IEnumerable<Alquiler>> FindByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Alquiler>> FindByArrendatarioIdAsync(int arrendatarioId);
    Task<IEnumerable<Alquiler>> FindBySolicitudIdAsync(int solicitudId);
}