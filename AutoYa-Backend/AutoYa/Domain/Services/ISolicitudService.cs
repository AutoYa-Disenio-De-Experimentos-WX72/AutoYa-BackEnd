using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Solicitud.
/// </summary>
public interface ISolicitudService
{
    /// <summary>
    /// Obtiene todas las solicitudes.
    /// </summary>
    Task<IEnumerable<Solicitud>> ListAsync();

    /// <summary>
    /// Obtiene todas las solicitudes asociadas a un alquiler específico.
    /// </summary>
    /// <param name="alquilerId">Identificador del alquiler.</param>
    Task<IEnumerable<Solicitud>> ListByAlquilerIdAsync(int alquilerId);

    /// <summary>
    /// Guarda una nueva solicitud.
    /// </summary>
    /// <param name="solicitud">Instancia de Solicitud a guardar.</param>
    Task<SolicitudResponse> SaveAsync(Solicitud solicitud);

    /// <summary>
    /// Actualiza la información de una solicitud existente.
    /// </summary>
    /// <param name="solicitudId">Identificador de la solicitud a actualizar.</param>
    /// <param name="solicitud">Instancia de Solicitud con la información actualizada.</param>
    Task<SolicitudResponse> UpdateAsync(int solicitudId, Solicitud solicitud);

    /// <summary>
    /// Elimina una solicitud existente.
    /// </summary>
    /// <param name="solicitudId">Identificador de la solicitud a eliminar.</param>
    Task<SolicitudResponse> DeleteAsync(int solicitudId);
}