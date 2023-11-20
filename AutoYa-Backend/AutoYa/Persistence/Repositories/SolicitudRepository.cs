using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las operaciones CRUD de las solicitudes de alquiler.
/// </summary>

public class SolicitudRepository : BaseRepository, ISolicitudRepository
{
    /// <summary>
    /// Inicializa una nueva instancia del repositorio SolicitudRepository utilizando el contexto de la aplicación proporcionado.
    /// </summary>
    /// <param name="context">Contexto de la base de datos utilizado para las operaciones de repositorio.</param>
    
    public SolicitudRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene una lista asincrónica de todas las solicitudes de alquiler.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene la lista de solicitudes.</returns>
    
    public async Task<IEnumerable<Solicitud>> ListAsync()
    {
        return await _context.Solicitudes.ToListAsync();
    }

    /// <summary>
    /// Agrega una nueva solicitud de alquiler de manera asincrónica al contexto de la base de datos.
    /// </summary>
    /// <param name="solicitud">La solicitud de alquiler a agregar.</param>
    
    public async Task AddAsync(Solicitud solicitud)
    {
        await _context.Solicitudes.AddAsync(solicitud);
    }

    /// <summary>
    /// Busca una solicitud de alquiler por su identificador de manera asincrónica.
    /// </summary>
    /// <param name="solicitudId">El identificador de la solicitud de alquiler a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene la solicitud encontrada o null.</returns>
    
    public async Task<Solicitud> FindByIdAsync(int solicitudId)
    {
        return await _context.Solicitudes.FindAsync(solicitudId);
    }

    /// <summary>
    /// Actualiza los datos de una solicitud de alquiler existente en el contexto de la base de datos.
    /// </summary>
    /// <param name="solicitud">La solicitud de alquiler a actualizar.</param>
    
    public void Update(Solicitud solicitud)
    {
        _context.Solicitudes.Update(solicitud);
    }

    /// <summary>
    /// Elimina una solicitud de alquiler del contexto de la base de datos.
    /// </summary>
    /// <param name="solicitud">La solicitud de alquiler a eliminar.</param>
    
    public void Remove(Solicitud solicitud)
    {
        _context.Solicitudes.Remove(solicitud);
    }

    /// <summary>
    /// Encuentra todas las solicitudes de alquiler asociadas a un identificador de alquiler específico de manera asincrónica.
    /// </summary>
    /// <param name="alquilerId">El identificador del alquiler asociado a las solicitudes.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene una lista de solicitudes.</returns>
    
    public async Task<IEnumerable<Solicitud>> FindByAlquilerIdAsync(int alquilerId)
    {
        return await _context.Solicitudes.Where(s => s.AlquilerId == alquilerId).ToListAsync();
    }
}