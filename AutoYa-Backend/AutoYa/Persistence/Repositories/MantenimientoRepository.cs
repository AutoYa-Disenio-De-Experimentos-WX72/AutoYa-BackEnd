using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class MantenimientoRepository : BaseRepository, IMantenimientoRepository
{
    public MantenimientoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Mantenimiento>> ListAsync()
    {
        return await _context.Mantenimientos.ToListAsync();
    }

    public async Task AddAsync(Mantenimiento mantenimiento)
    {
        await _context.Mantenimientos.AddAsync(mantenimiento);
    }

    public async Task<Mantenimiento> FindByIdAsync(int mantenimientoId)
    {
        return await _context.Mantenimientos.FindAsync(mantenimientoId);
    }

    public void Update(Mantenimiento mantenimiento)
    {
        _context.Mantenimientos.Update(mantenimiento);
    }

    public void Remove(Mantenimiento mantenimiento)
    {
        _context.Mantenimientos.Remove(mantenimiento);
    }

    public async Task<IEnumerable<Mantenimiento>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Mantenimientos.Where(m => m.ArrendatarioId == arrendatarioId).ToListAsync();
    }

    public async Task<IEnumerable<Mantenimiento>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Mantenimientos.Where(m => m.PropietarioId == propietarioId).ToListAsync();
    }
}