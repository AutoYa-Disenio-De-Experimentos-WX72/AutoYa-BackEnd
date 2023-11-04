using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface ISolicitudRepository
{
    Task<IEnumerable<Solicitud>> ListAsync();
    Task AddAsync(Solicitud solicitud);
    Task<Solicitud> FindByIdAsync(int solicitudId);
    void Update(Solicitud solicitud);
    void Remove(Solicitud solicitud);
    Task<IEnumerable<Solicitud>> FindByAlquilerIdAsync(int alquilerId);
}