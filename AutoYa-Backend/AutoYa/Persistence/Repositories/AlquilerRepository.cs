using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class AlquilerRepository : BaseRepository, IAlquilerRepository
{
    public AlquilerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Alquiler>> ListAsync()
    {
        return await _context.Alquileres.ToListAsync();
    }

    public async Task AddAsync(Alquiler alquiler)
    {
        await _context.Alquileres.AddAsync(alquiler);
    }

    public async Task<Alquiler> FindByIdAsync(int? alquilerId)
    {
        return await _context.Alquileres.FindAsync(alquilerId);
    }

    public void Update(Alquiler alquiler)
    {
        _context.Alquileres.Update(alquiler);
    }

    public void Remove(Alquiler alquiler)
    {
        _context.Alquileres.Remove(alquiler);
    }

    public async Task<IEnumerable<Alquiler>> FindByVehiculoIdAsync(int vehiculoId)
    {
        return await _context.Alquileres.Where(a => a.VehiculoId == vehiculoId).ToListAsync();
    }

    public async Task<IEnumerable<Alquiler>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Alquileres.Where(a => a.PropietarioId == propietarioId).ToListAsync();
    }

    public async Task<IEnumerable<Alquiler>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Alquileres.Where(a => a.ArrendatarioId == arrendatarioId).ToListAsync();
    }

    public async Task<IEnumerable<Alquiler>> FindBySolicitudIdAsync(int solicitudId)
    {
        return await _context.Alquileres.Where(a => a.SolicitudId == solicitudId).ToListAsync();
    }
}