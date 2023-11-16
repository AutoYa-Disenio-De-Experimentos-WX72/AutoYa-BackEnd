using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class ArrendatarioRepository : BaseRepository, IArrendatarioRepository
{
    public ArrendatarioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Arrendatario>> ListAsync()
    {
        return await _context.Arrendatarios.ToListAsync();
    }

    public async Task AddAsync(Arrendatario arrendatario)
    {
        await _context.Arrendatarios.AddAsync(arrendatario);
    }

    public async Task<Arrendatario> FindByIdAsync(int? arrendatarioId)
    {
        return await _context.Arrendatarios.FindAsync(arrendatarioId);
    }

    public async Task<Arrendatario> FindByEmailAsync(string email)
    {
        return await _context.Arrendatarios.FirstOrDefaultAsync(a => a.Correo == email);
    }

    public void Update(Arrendatario arrendatario)
    {
        _context.Arrendatarios.Update(arrendatario);
    }

    public void Remove(Arrendatario arrendatario)
    {
        _context.Arrendatarios.Remove(arrendatario);
    }
}