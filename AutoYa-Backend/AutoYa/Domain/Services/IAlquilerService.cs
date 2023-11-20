using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Alquiler.
/// </summary>
public interface IAlquilerService
{
    /// <summary>
    /// Obtiene todos los alquileres.
    /// </summary>
    Task<IEnumerable<Alquiler>> ListAsync();

    /// <summary>
    /// Obtiene los alquileres asociados a un vehículo específico.
    /// </summary>
    Task<IEnumerable<Alquiler>> ListByVehiculoIdAsync(int vehiculoId);

    /// <summary>
    /// Obtiene los alquileres asociados a un propietario específico.
    /// </summary>
    Task<IEnumerable<Alquiler>> ListByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Obtiene los alquileres asociados a un arrendatario específico.
    /// </summary>
    Task<IEnumerable<Alquiler>> ListByArrendatarioIdAsync(int arrendatarioId);

    /// <summary>
    /// Guarda un nuevo alquiler.
    /// </summary>
    /// <param name="alquiler">Instancia de Alquiler a guardar.</param>
    Task<AlquilerResponse> SaveAsync(Alquiler alquiler);

    /// <summary>
    /// Actualiza la información de un alquiler existente.
    /// </summary>
    /// <param name="alquilerId">Identificador del alquiler a actualizar.</param>
    /// <param name="alquiler">Instancia de Alquiler con la información actualizada.</param>
    Task<AlquilerResponse> UpdateAsync(int alquilerId, Alquiler alquiler);

    /// <summary>
    /// Elimina un alquiler existente.
    /// </summary>
    /// <param name="alquilerId">Identificador del alquiler a eliminar.</param>
    Task<AlquilerResponse> DeleteAsync(int alquilerId);
}