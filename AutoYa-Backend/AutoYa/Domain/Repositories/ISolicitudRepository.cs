using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Solicitud.
/// </summary>
public interface ISolicitudRepository
{
    /// <summary>
    /// Obtiene todos los registros de solicitudes en el sistema.
    /// </summary>
    Task<IEnumerable<Solicitud>> ListAsync();

    /// <summary>
    /// Agrega una nueva solicitud al sistema.
    /// </summary>
    Task AddAsync(Solicitud solicitud);

    /// <summary>
    /// Busca una solicitud por su identificador único.
    /// </summary>
    Task<Solicitud> FindByIdAsync(int solicitudId);

    /// <summary>
    /// Actualiza la información de una solicitud existente.
    /// </summary>
    void Update(Solicitud solicitud);

    /// <summary>
    /// Elimina una solicitud del sistema.
    /// </summary>
    void Remove(Solicitud solicitud);

    /// <summary>
    /// Busca solicitudes asociadas a un alquiler específico.
    /// </summary>
    Task<IEnumerable<Solicitud>> FindByAlquilerIdAsync(int alquilerId);
}