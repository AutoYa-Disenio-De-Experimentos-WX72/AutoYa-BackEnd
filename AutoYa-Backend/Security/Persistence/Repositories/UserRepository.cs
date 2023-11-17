using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.Security.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Usuarios.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Usuarios.Any(x => x.Email == email);
    }

    public User FindById(int id)
    {
        return _context.Usuarios.Find(id);
    }

    public void Update(User user)
    {
        _context.Usuarios.Update(user);
    }

    public void Remove(User user)
    {
        _context.Usuarios.Remove(user);
    }
}