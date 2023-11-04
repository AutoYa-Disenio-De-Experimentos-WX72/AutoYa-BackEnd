using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class NotificacionRepository : BaseRepository, INotificacionRepository
{
    public NotificacionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Notificacion>> ListAsync()
    {
        return await _context.Notificaciones.ToListAsync();
    }

    public async Task AddAsync(Notificacion notificacion)
    {
        await _context.Notificaciones.AddAsync(notificacion);
    }

    public async Task<Notificacion> FindByIdAsync(int notificacionId)
    {
        return await _context.Notificaciones.FindAsync(notificacionId);
    }

    public void Update(Notificacion notificacion)
    {
        _context.Notificaciones.Update(notificacion);
    }

    public void Remove(Notificacion notificacion)
    {
        _context.Notificaciones.Remove(notificacion);
    }

    public async Task<IEnumerable<Notificacion>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Notificaciones.Where(n => n.PropietarioId == propietarioId).ToListAsync();
    }

    public async Task<IEnumerable<Notificacion>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Notificaciones.Where(n => n.ArrendatarioId == arrendatarioId).ToListAsync();
    }
}