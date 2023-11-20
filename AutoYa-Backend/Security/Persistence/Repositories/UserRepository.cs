using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.Security.Persistence.Repositories;

/// <summary>
/// Clase que representa un repositorio de usuarios.
/// </summary>
public class UserRepository : BaseRepository, IUserRepository
{
    /// <summary>
    /// Constructor que inicializa el contexto de la aplicación.
    /// </summary>
    /// <param name="context">El contexto de la aplicación.</param>
    public UserRepository(AppDbContext context) : base(context)
    {
    }
    
    /// <summary>
    /// Obtiene una lista de todos los usuarios de forma asíncrona.
    /// </summary>
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    /// <summary>
    /// Añade un usuario de forma asíncrona.
    /// </summary>
    /// <param name="user">El usuario a añadir.</param>
    public async Task AddAsync(User user)
    {
        await _context.Usuarios.AddAsync(user);
    }

    /// <summary>
    /// Encuentra un usuario por su ID de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    /// <summary>
    /// Encuentra un usuario por su correo electrónico de forma asíncrona.
    /// </summary>
    /// <param name="email">El correo electrónico del usuario.</param>
    public async Task<User> FindByEmailAsync(string email)
    {
        return await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == email);
    }

    /// <summary>
    /// Verifica si existe un usuario con el correo electrónico dado.
    /// </summary>
    /// <param name="email">El correo electrónico a verificar.</param>
    public bool ExistsByEmail(string email)
    {
        return _context.Usuarios.Any(x => x.Email == email);
    }

    /// <summary>
    /// Encuentra un usuario por su ID.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    public User FindById(int id)
    {
        return _context.Usuarios.Find(id);
    }

    /// <summary>
    /// Actualiza un usuario.
    /// </summary>
    /// <param name="user">El usuario a actualizar.</param>
    public void Update(User user)
    {
        _context.Usuarios.Update(user);
    }

    /// <summary>
    /// Elimina un usuario.
    /// </summary>
    /// <param name="user">El usuario a eliminar.</param>
    public void Remove(User user)
    {
        _context.Usuarios.Remove(user);
    }
}