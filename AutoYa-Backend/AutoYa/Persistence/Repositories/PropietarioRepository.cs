using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class PropietarioRepository : BaseRepository, IPropietarioRepository
{
    public PropietarioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Propietario>> ListAsync()
    {
        return await _context.Propietarios.ToListAsync();
    }

    public async Task AddAsync(Propietario propietario)
    {
        await _context.Propietarios.AddAsync(propietario);
    }

    public async Task<Propietario> FindByIdAsync(int propietarioId)
    {
        return await _context.Propietarios.FindAsync(propietarioId);
    }

    public void Update(Propietario propietario)
    {
        _context.Propietarios.Update(propietario);
    }

    public void Remove(Propietario propietario)
    {
        _context.Propietarios.Remove(propietario);
    }
}