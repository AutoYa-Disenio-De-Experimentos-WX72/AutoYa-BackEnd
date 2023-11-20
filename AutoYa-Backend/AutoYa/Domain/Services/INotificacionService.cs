using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Notificacion.
/// </summary>
public interface INotificacionService
{
    /// <summary>
    /// Obtiene todas las notificaciones.
    /// </summary>
    Task<IEnumerable<Notificacion>> ListAsync();

    /// <summary>
    /// Obtiene las notificaciones asociadas a un propietario específico.
    /// </summary>
    /// <param name="propietarioId">Identificador del propietario.</param>
    Task<IEnumerable<Notificacion>> ListByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Obtiene las notificaciones asociadas a un arrendatario específico.
    /// </summary>
    /// <param name="arrendatarioId">Identificador del arrendatario.</param>
    Task<IEnumerable<Notificacion>> ListByArrendatarioIdAsync(int arrendatarioId);

    /// <summary>
    /// Guarda una nueva notificacion.
    /// </summary>
    /// <param name="notificacion">Instancia de Notificacion a guardar.</param>
    Task<NotificacionResponse> SaveAsync(Notificacion notificacion);

    /// <summary>
    /// Actualiza la información de una notificacion existente.
    /// </summary>
    /// <param name="notificacionId">Identificador de la notificacion a actualizar.</param>
    /// <param name="notificacion">Instancia de Notificacion con la información actualizada.</param>
    Task<NotificacionResponse> UpdateAsync(int notificacionId, Notificacion notificacion);

    /// <summary>
    /// Elimina una notificacion existente.
    /// </summary>
    /// <param name="notificacionId">Identificador de la notificacion a eliminar.</param>
    Task<NotificacionResponse> DeleteAsync(int notificacionId);
}