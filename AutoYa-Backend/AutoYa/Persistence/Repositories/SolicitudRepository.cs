using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class SolicitudRepository : BaseRepository, ISolicitudRepository
{
    public SolicitudRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Solicitud>> ListAsync()
    {
        return await _context.Solicitudes.ToListAsync();
    }

    public async Task AddAsync(Solicitud solicitud)
    {
        await _context.Solicitudes.AddAsync(solicitud);
    }

    public async Task<Solicitud> FindByIdAsync(int solicitudId)
    {
        return await _context.Solicitudes.FindAsync(solicitudId);
    }

    public void Update(Solicitud solicitud)
    {
        _context.Solicitudes.Update(solicitud);
    }

    public void Remove(Solicitud solicitud)
    {
        _context.Solicitudes.Remove(solicitud);
    }

    public async Task<IEnumerable<Solicitud>> FindByAlquilerIdAsync(int alquilerId)
    {
        return await _context.Solicitudes.Where(s => s.AlquilerId == alquilerId).ToListAsync();
    }
}