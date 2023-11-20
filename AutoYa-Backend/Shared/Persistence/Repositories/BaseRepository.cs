using AutoYa_Backend.Shared.Persistence.Contexts;

namespace AutoYa_Backend.Shared.Persistence.Repositories;

/// <summary>
/// Clase base que representa un repositorio.
/// </summary>
public class BaseRepository
{
    /// <summary>
    /// El contexto de la aplicación.
    /// </summary>
    protected readonly AppDbContext _context;
    
    /// <summary>
    /// Constructor que inicializa el contexto de la aplicación.
    /// </summary>
    /// <param name="context">El contexto de la aplicación.</param>
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}