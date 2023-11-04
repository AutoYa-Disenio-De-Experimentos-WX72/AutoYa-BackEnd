using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface INotificacionRepository
{
    Task<IEnumerable<Notificacion>> ListAsync();
    Task AddAsync(Notificacion notificacion);
    Task<Notificacion> FindByIdAsync(int notificacionId);
    void Update(Notificacion notificacion);
    void Remove(Notificacion notificacion);
    Task<IEnumerable<Notificacion>> FindByPropietarioIdAsync(int propietarioId);
    Task<IEnumerable<Notificacion>> FindByArrendatarioIdAsync(int arrendatarioId);
}