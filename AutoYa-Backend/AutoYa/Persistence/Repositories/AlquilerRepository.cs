using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Espacio de nombres para las implementaciones de repositorios de AutoYa_Backend.
/// </summary>

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las operaciones de la entidad Alquiler.
/// </summary>

public class AlquilerRepository : BaseRepository, IAlquilerRepository
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase AlquilerRepository con el contexto de base de datos especificado.
    /// </summary>
    /// <param name="context">El contexto de base de datos a utilizar.</param>
    
    public AlquilerRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Lista asincrónicamente todos los alquileres.
    /// </summary>
    /// <returns>Una colección de alquileres.</returns>

    public async Task<IEnumerable<Alquiler>> ListAsync()
    {
        return await _context.Alquileres.ToListAsync();
    }

    /// <summary>
    /// Agrega asincrónicamente un nuevo alquiler al contexto de la base de datos.
    /// </summary>
    /// <param name="alquiler">El alquiler a agregar.</param>
    
    public async Task AddAsync(Alquiler alquiler)
    {
        await _context.Alquileres.AddAsync(alquiler);
    }

     /// <summary>
    /// Encuentra asincrónicamente un alquiler por su identificador.
    /// </summary>
    /// <param name="alquilerId">El identificador del alquiler.</param>
    /// <returns>El alquiler encontrado o null si no se encuentra.</returns>

    public async Task<Alquiler> FindByIdAsync(int? alquilerId)
    {
        return await _context.Alquileres.FindAsync(alquilerId);
    }

    /// <summary>
    /// Actualiza un alquiler existente en el contexto de la base de datos.
    /// </summary>
    /// <param name="alquiler">El alquiler a actualizar.</param>
    
    public void Update(Alquiler alquiler)
    {
        _context.Alquileres.Update(alquiler);
    }

    /// <summary>
    /// Elimina un alquiler del contexto de la base de datos.
    /// </summary>
    /// <param name="alquiler">El alquiler a eliminar.</param>
    
    public void Remove(Alquiler alquiler)
    {
        _context.Alquileres.Remove(alquiler);
    }

    /// <summary>
    /// Encuentra asincrónicamente todos los alquileres relacionados con un vehículo específico por su identificador.
    /// </summary>
    /// <param name="vehiculoId">El identificador del vehículo asociado a los alquileres.</param>
    /// <returns>Una colección de alquileres.</returns>
    
    public async Task<IEnumerable<Alquiler>> FindByVehiculoIdAsync(int vehiculoId)
    {
        return await _context.Alquileres.Where(a => a.VehiculoId == vehiculoId).ToListAsync();
    }

    /// <summary>
    /// Encuentra asincrónicamente todos los alquileres relacionados con un propietario específico por su identificador.
    /// </summary>
    /// <param name="propietarioId">El identificador del propietario asociado a los alquileres.</param>
    /// <returns>Una colección de alquileres.</returns>
    
    public async Task<IEnumerable<Alquiler>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Alquileres.Where(a => a.PropietarioId == propietarioId).ToListAsync();
    }

    /// <summary>
    /// Encuentra asincrónicamente todos los alquileres relacionados con un arrendatario específico por su identificador.
    /// </summary>
    /// <param name="arrendatarioId">El identificador del arrendatario asociado a los alquileres.</param>
    /// <returns>Una colección de alquileres.</returns>
    
    public async Task<IEnumerable<Alquiler>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Alquileres.Where(a => a.ArrendatarioId == arrendatarioId).ToListAsync();
    }
}