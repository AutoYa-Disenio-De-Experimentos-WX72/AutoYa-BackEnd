using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las operaciones CRUD de los mantenimientos de vehículos.
/// </summary>

public class NotificacionRepository : BaseRepository, INotificacionRepository
{

    /// <summary>
    /// Inicializa una nueva instancia del repositorio MantenimientoRepository utilizando el contexto de la aplicación proporcionado.
    /// </summary>
    /// <param name="context">Contexto de la base de datos utilizado para las operaciones de repositorio.</param>
    
    public NotificacionRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene una lista asincrónica de todos los mantenimientos.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene la lista de mantenimientos.</returns>
    
    public async Task<IEnumerable<Notificacion>> ListAsync()
    {
        return await _context.Notificaciones.ToListAsync();
    }

    /// <summary>
    /// Agrega un nuevo mantenimiento de manera asincrónica al contexto de la base de datos.
    /// </summary>
    /// <param name="mantenimiento">El mantenimiento a agregar.</param>
    
    public async Task AddAsync(Notificacion notificacion)
    {
        await _context.Notificaciones.AddAsync(notificacion);
    }

    /// <summary>
    /// Busca un mantenimiento por su identificador de manera asincrónica.
    /// </summary>
    /// <param name="mantenimientoId">El identificador del mantenimiento a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene el mantenimiento encontrado o null.</returns>
    
    public async Task<Notificacion> FindByIdAsync(int notificacionId)
    {
        return await _context.Notificaciones.FindAsync(notificacionId);
    }

    /// <summary>
    /// Actualiza los datos de un mantenimiento existente en el contexto de la base de datos.
    /// </summary>
    /// <param name="mantenimiento">El mantenimiento a actualizar.</param>
    
    public void Update(Notificacion notificacion)
    {
        _context.Notificaciones.Update(notificacion);
    }

    /// <summary>
    /// Elimina un mantenimiento del contexto de la base de datos.
    /// </summary>
    /// <param name="mantenimiento">El mantenimiento a eliminar.</param>
    
    public void Remove(Notificacion notificacion)
    {
        _context.Notificaciones.Remove(notificacion);
    }

    /// <summary>
    /// Encuentra todos los mantenimientos relacionados con un arrendatario específico de manera asincrónica.
    /// </summary>
    /// <param name="arrendatarioId">El identificador del arrendatario asociado a los mantenimientos.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene una lista de mantenimientos.</returns>
    
    public async Task<IEnumerable<Notificacion>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Notificaciones.Where(n => n.PropietarioId == propietarioId).ToListAsync();
    }

    /// <summary>
    /// Encuentra todos los mantenimientos relacionados con un propietario específico de manera asincrónica.
    /// </summary>
    /// <param name="propietarioId">El identificador del propietario asociado a los mantenimientos.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene una lista de mantenimientos.</returns>
    
    public async Task<IEnumerable<Notificacion>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Notificaciones.Where(n => n.ArrendatarioId == arrendatarioId).ToListAsync();
    }
}