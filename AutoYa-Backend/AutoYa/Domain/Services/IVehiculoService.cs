using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Vehiculo.
/// </summary>
public interface IVehiculoService
{
    /// <summary>
    /// Obtiene todos los vehículos.
    /// </summary>
    Task<IEnumerable<Vehiculo>> ListAsync();

    /// <summary>
    /// Obtiene todos los vehículos asociados a un propietario específico.
    /// </summary>
    /// <param name="propietarioId">Identificador del propietario.</param>
    Task<IEnumerable<Vehiculo>> ListByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Obtiene todos los vehículos asociados a un arrendatario específico.
    /// </summary>
    /// <param name="arrendatarioId">Identificador del arrendatario.</param>
    Task<IEnumerable<Vehiculo>> ListByArrendatarioIdAsync(int arrendatarioId);

    /// <summary>
    /// Obtiene todos los vehículos asociados a un alquiler específico.
    /// </summary>
    /// <param name="alquilerId">Identificador del alquiler.</param>
    Task<IEnumerable<Vehiculo>> ListByAlquilerIdAsync(int alquilerId);

    /// <summary>
    /// Guarda un nuevo vehículo.
    /// </summary>
    /// <param name="vehiculo">Instancia de Vehiculo a guardar.</param>
    Task<VehiculoResponse> SaveAsync(Vehiculo vehiculo);

    /// <summary>
    /// Actualiza la información de un vehículo existente.
    /// </summary>
    /// <param name="vehiculoId">Identificador del vehículo a actualizar.</param>
    /// <param name="vehiculo">Instancia de Vehiculo con la información actualizada.</param>
    Task<VehiculoResponse> UpdateAsync(int vehiculoId, Vehiculo vehiculo);

    /// <summary>
    /// Elimina un vehículo existente.
    /// </summary>
    /// <param name="vehiculoId">Identificador del vehículo a eliminar.</param>
    Task<VehiculoResponse> DeleteAsync(int vehiculoId);
}