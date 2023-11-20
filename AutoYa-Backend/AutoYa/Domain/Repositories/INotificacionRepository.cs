using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Notificacion.
/// </summary>
public interface INotificacionRepository
{
    /// <summary>
    /// Obtiene todos los registros de notificaciones en el sistema.
    /// </summary>
    Task<IEnumerable<Notificacion>> ListAsync();

    /// <summary>
    /// Agrega una nueva notificación al sistema.
    /// </summary>
    Task AddAsync(Notificacion notificacion);

    /// <summary>
    /// Busca una notificación por su identificador único.
    /// </summary>
    Task<Notificacion> FindByIdAsync(int notificacionId);

    /// <summary>
    /// Actualiza la información de una notificación existente.
    /// </summary>
    void Update(Notificacion notificacion);

    /// <summary>
    /// Elimina una notificación del sistema.
    /// </summary>
    void Remove(Notificacion notificacion);

    /// <summary>
    /// Busca notificaciones asociadas a un propietario específico.
    /// </summary>
    Task<IEnumerable<Notificacion>> FindByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Busca notificaciones asociadas a un arrendatario específico.
    /// </summary>
    Task<IEnumerable<Notificacion>> FindByArrendatarioIdAsync(int arrendatarioId);
}