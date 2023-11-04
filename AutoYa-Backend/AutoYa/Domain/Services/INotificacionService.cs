using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface INotificacionService
{
    Task<IEnumerable<Notificacion>> ListAsync();
    Task<IEnumerable<Notificacion>> ListByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Notificacion>> ListByArrendatarioIdAsync(int arrendatarioId);
    Task<NotificacionResponse> SaveAsync(Notificacion notificacion);
    Task<NotificacionResponse> UpdateAsync(int notificacionId, Notificacion notificacion);
    Task<NotificacionResponse> DeleteAsync(int notificacionId);
}