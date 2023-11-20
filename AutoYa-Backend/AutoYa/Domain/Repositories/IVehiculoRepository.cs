using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Vehiculo.
/// </summary>
public interface IVehiculoRepository
{
    /// <summary>
    /// Obtiene todos los registros de vehículos en el sistema.
    /// </summary>
    Task<IEnumerable<Vehiculo>> ListAsync();

    /// <summary>
    /// Agrega un nuevo vehículo al sistema.
    /// </summary>
    Task AddAsync(Vehiculo vehiculo);

    /// <summary>
    /// Busca un vehículo por su identificador único.
    /// </summary>
    Task<Vehiculo> FindByIdAsync(int vehiculoId);

    /// <summary>
    /// Actualiza la información de un vehículo existente.
    /// </summary>
    void Update(Vehiculo vehiculo);

    /// <summary>
    /// Elimina un vehículo del sistema.
    /// </summary>
    void Remove(Vehiculo vehiculo);

    /// <summary>
    /// Busca vehículos asociados a un propietario específico.
    /// </summary>
    Task<IEnumerable<Vehiculo>> FindByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Busca vehículos asociados a un arrendatario específico.
    /// </summary>
    Task<IEnumerable<Vehiculo>> FindByArrendatarioIdAsync(int arrendatarioId);

    /// <summary>
    /// Busca vehículos asociados a un alquiler específico.
    /// </summary>
    Task<IEnumerable<Vehiculo>> FindByAlquilerIdAsync(int alquilerId);
}