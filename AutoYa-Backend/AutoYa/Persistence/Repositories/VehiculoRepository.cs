using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las operaciones CRUD para los vehículos.
/// </summary>

public class VehiculoRepository : BaseRepository, IVehiculoRepository
{

    /// <summary>
    /// Inicializa una nueva instancia del repositorio VehiculoRepository utilizando el contexto de la aplicación proporcionado.
    /// </summary>
    /// <param name="context">Contexto de la base de datos utilizado para las operaciones de repositorio.</param>
    
    public VehiculoRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene una lista asincrónica de todos los vehículos, incluyendo sus propietarios, arrendatarios y alquileres asociados.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene la lista de vehículos.</returns>
    
    public async Task<IEnumerable<Vehiculo>> ListAsync()
    {
        return await _context.Vehiculos
            .Include(v => v.Propietario)
            .Include(v => v.Arrendatario)
            .Include(v => v.Alquiler)
            .ToListAsync();
    }

    /// <summary>
    /// Agrega un nuevo vehículo de manera asincrónica al contexto de la base de datos.
    /// </summary>
    /// <param name="vehiculo">El vehículo a agregar.</param>
    
    public async Task AddAsync(Vehiculo vehiculo)
    {
        await _context.Vehiculos.AddAsync(vehiculo);
    }

    /// <summary>
    /// Busca un vehículo por su identificador de manera asincrónica.
    /// </summary>
    /// <param name="vehiculoId">El identificador del vehículo a buscar.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene el vehículo encontrado o null.</returns>
    
    public async Task<Vehiculo> FindByIdAsync(int vehiculoId)
    {
        return await _context.Vehiculos.FindAsync(vehiculoId);
    }

    /// <summary>
    /// Actualiza los datos de un vehículo existente en el contexto de la base de datos.
    /// </summary>
    /// <param name="vehiculo">El vehículo a actualizar.</param>
    
    public void Update(Vehiculo vehiculo)
    {
        _context.Vehiculos.Update(vehiculo);
    }

    /// <summary>
    /// Elimina un vehículo del contexto de la base de datos.
    /// </summary>
    /// <param name="vehiculo">El vehículo a eliminar.</param>
    
    public void Remove(Vehiculo vehiculo)
    {
        _context.Vehiculos.Remove(vehiculo);
    }

    /// <summary>
    /// Encuentra todos los vehículos asociados a un propietario específico de manera asincrónica.
    /// </summary>
    /// <param name="propietarioId">El identificador del propietario asociado a los vehículos.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene una lista de vehículos.</returns>
    
    public async Task<IEnumerable<Vehiculo>> FindByPropietarioIdAsync(int propietarioId)
    {
        return await _context.Vehiculos.Where(v => v.PropietarioId == propietarioId).ToListAsync();
    }

    /// <summary>
    /// Encuentra todos los vehículos asociados a un arrendatario específico de manera asincrónica.
    /// </summary>
    /// <param name="arrendatarioId">El identificador del arrendatario asociado a los vehículos.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene una lista de vehículos.</returns>
    
    public async Task<IEnumerable<Vehiculo>> FindByArrendatarioIdAsync(int arrendatarioId)
    {
        return await _context.Vehiculos.Where(v => v.ArrendatarioId == arrendatarioId).ToListAsync();
    }

    /// <summary>
    /// Encuentra todos los vehículos asociados a un alquiler específico de manera asincrónica.
    /// </summary>
    /// <param name="alquilerId">El identificador del alquiler asociado a los vehículos.</param>
    /// <returns>Una tarea que representa la operación asincrónica, que contiene una lista de vehículos.</returns>
    
    public async Task<IEnumerable<Vehiculo>> FindByAlquilerIdAsync(int alquilerId)
    {
        return await _context.Vehiculos.Where(v => v.AlquilerId == alquilerId).ToListAsync();
    }
}