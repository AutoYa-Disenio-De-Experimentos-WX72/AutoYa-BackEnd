using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Alquiler.
/// </summary>
public interface IAlquilerRepository
{
    /// <summary>
    /// Obtiene todos los alquileres en el sistema.
    /// </summary>
    Task<IEnumerable<Alquiler>> ListAsync();

    /// <summary>
    /// Agrega un nuevo alquiler al sistema.
    /// </summary>
    Task AddAsync(Alquiler alquiler);

    /// <summary>
    /// Busca un alquiler por su identificador único.
    /// </summary>
    Task<Alquiler> FindByIdAsync(int? alquilerId);

    /// <summary>
    /// Actualiza la información de un alquiler existente.
    /// </summary>
    void Update(Alquiler alquiler);

    /// <summary>
    /// Elimina un alquiler del sistema.
    /// </summary>
    void Remove(Alquiler alquiler);

    /// <summary>
    /// Busca alquileres asociados a un vehículo específico.
    /// </summary>
    Task<IEnumerable<Alquiler>> FindByVehiculoIdAsync(int vehiculoId);

    /// <summary>
    /// Busca alquileres asociados a un propietario específico.
    /// </summary>
    Task<IEnumerable<Alquiler>> FindByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Busca alquileres asociados a un arrendatario específico.
    /// </summary>
    Task<IEnumerable<Alquiler>> FindByArrendatarioIdAsync(int arrendatarioId);
}