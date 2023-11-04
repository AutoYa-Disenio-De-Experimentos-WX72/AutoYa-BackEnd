using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ISolicitudService
{
    Task<IEnumerable<Solicitud>> ListAsync();
    Task<IEnumerable<Solicitud>> ListByAlquilerIdAsync(int alquilerId);
    Task<SolicitudResponse> SaveAsync(Solicitud solicitud);
    Task<SolicitudResponse> UpdateAsync(int solicitudId, Solicitud solicitud);
    Task<SolicitudResponse> DeleteAsync(int solicitudId);
}