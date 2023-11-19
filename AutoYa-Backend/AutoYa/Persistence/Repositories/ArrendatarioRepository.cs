using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las operaciones CRUD de los arrendatarios.
/// </summary>

public class ArrendatarioRepository : BaseRepository, IArrendatarioRepository
{

    /// <summary>
    /// Inicializa una nueva instancia del repositorio ArrendatarioRepository utilizando el contexto de la aplicación proporcionado.
    /// </summary>
    /// <param name="context">Contexto de la base de datos utilizado para las operaciones de repositorio.</param>
    
    public ArrendatarioRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene una lista asincrónica de todos los arrendatarios.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene la lista de arrendatarios.</returns>
    
    public async Task<IEnumerable<Arrendatario>> ListAsync()
    {
        return await _context.Arrendatarios.ToListAsync();
    }

    /// <summary>
    /// Agrega un nuevo arrendatario de manera asincrónica al contexto de la base de datos.
    /// </summary>
    /// <param name="arrendatario">El arrendatario a agregar.</param>
    
    public async Task AddAsync(Arrendatario arrendatario)
    {
        await _context.Arrendatarios.AddAsync(arrendatario);
    }

    /// <summary>
    /// Busca un arrendatario por su identificador de manera asincrónica.
    /// </summary>
    /// <param name="arrendatarioId">El identificador del arrendatario a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene el arrendatario encontrado o null.</returns>
    
    public async Task<Arrendatario> FindByIdAsync(int? arrendatarioId)
    {
        return await _context.Arrendatarios.FindAsync(arrendatarioId);
    }

    /// <summary>
    /// Busca un arrendatario por su correo electrónico de manera asincrónica.
    /// </summary>
    /// <param name="email">El correo electrónico del arrendatario a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene el arrendatario encontrado o null.</returns>
    
    public async Task<Arrendatario> FindByEmailAsync(string email)
    {
        return await _context.Arrendatarios.FirstOrDefaultAsync(a => a.Correo == email);
    }

    /// <summary>
    /// Actualiza los datos de un arrendatario existente en el contexto de la base de datos.
    /// </summary>
    /// <param name="arrendatario">El arrendatario a actualizar.</param>
    
    public void Update(Arrendatario arrendatario)
    {
        _context.Arrendatarios.Update(arrendatario);
    }

    /// <summary>
    /// Elimina un arrendatario del contexto de la base de datos.
    /// </summary>
    /// <param name="arrendatario">El arrendatario a eliminar.</param>
    
    public void Remove(Arrendatario arrendatario)
    {
        _context.Arrendatarios.Remove(arrendatario);
    }
}