using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class VehiculoReposiroty : BaseRepository, IVehiculoRepository
{
    public VehiculoReposiroty(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Vehiculo>> ListAsync()
    {
        return await _context.Vehiculos.Include(v => v.Propietario).ToListAsync();
    }

    public async Task AddAsync(Vehiculo vehiculo)
    {
        await _context.Vehiculos.AddAsync(vehiculo);
    }

    public async Task<Vehiculo> FindByIdAsync(int vehiculoId)
    {
        return await _context.Vehiculos.FindAsync(vehiculoId);
    }

    public void Update(Vehiculo vehiculo)
    {
        _context.Vehiculos.Update(vehiculo);
    }

    public void Remove(Vehiculo vehiculo)
    {
        _context.Vehiculos.Remove(vehiculo);
    }

    public async Task<IEnumerable<Vehiculo>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Vehiculos.Where(v => v.PropietarioId == propietarioId).ToListAsync();
    }

    public async Task<IEnumerable<Vehiculo>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Vehiculos.Where(v => v.ArrendatarioId == arrendatarioId).ToListAsync();
    }

    public async Task<IEnumerable<Vehiculo>> FindByAlquilerIdAsync(int alquilerId)
    {
        return await _context.Vehiculos.Where(v => v.AlquilerId == alquilerId).ToListAsync();
    }
}