using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las operaciones CRUD para los propietarios.
/// </summary>
/// 
public class PropietarioRepository : BaseRepository, IPropietarioRepository
{

    /// <summary>
    /// Inicializa una nueva instancia del repositorio PropietarioRepository utilizando el contexto de la aplicación proporcionado.
    /// </summary>
    /// <param name="context">Contexto de la base de datos utilizado para las operaciones de repositorio.</param>
    
    public PropietarioRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene una lista asincrónica de todos los propietarios.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene la lista de propietarios.</returns>
    
    public async Task<IEnumerable<Propietario>> ListAsync()
    {
        return await _context.Propietarios.ToListAsync();
    }

    /// <summary>
    /// Agrega un nuevo propietario de manera asincrónica al contexto de la base de datos.
    /// </summary>
    /// <param name="propietario">El propietario a agregar.</param>
    
    public async Task AddAsync(Propietario propietario)
    {
        await _context.Propietarios.AddAsync(propietario);
    }

    /// <summary>
    /// Busca un propietario por su identificador de manera asincrónica.
    /// </summary>
    /// <param name="propietarioId">El identificador del propietario a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene el propietario encontrado o null.</returns>
    
    public async Task<Propietario> FindByIdAsync(int propietarioId)
    {
        return await _context.Propietarios.FindAsync(propietarioId);
    }

    /// <summary>
    /// Actualiza los datos de un propietario existente en el contexto de la base de datos.
    /// </summary>
    /// <param name="propietario">El propietario a actualizar.</param>
    
    public void Update(Propietario propietario)
    {
        _context.Propietarios.Update(propietario);
    }

    /// <summary>
    /// Elimina un propietario del contexto de la base de datos.
    /// </summary>
    /// <param name="propietario">El propietario a eliminar.</param>
    
    public void Remove(Propietario propietario)
    {
        _context.Propietarios.Remove(propietario);
    }

    /// <summary>
    /// Encuentra un propietario por su correo electrónico de manera asincrónica.
    /// </summary>
    /// <param name="email">El correo electrónico del propietario a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene el propietario encontrado o null.</returns>
    
    public async Task<Propietario> FindByEmailAsync(string email)
    {
        return await _context.Propietarios.FirstOrDefaultAsync(a => a.Correo == email);
    }
}