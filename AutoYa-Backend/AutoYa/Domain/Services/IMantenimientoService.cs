using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Mantenimiento.
/// </summary>
public interface IMantenimientoService
{
    /// <summary>
    /// Obtiene todos los mantenimientos.
    /// </summary>
    Task<IEnumerable<Mantenimiento>> ListAsync();

    /// <summary>
    /// Obtiene los mantenimientos asociados a un propietario específico.
    /// </summary>
    /// <param name="propietarioId">Identificador del propietario.</param>
    Task<IEnumerable<Mantenimiento>> ListByPropietarioIdAsync(int propietarioId);

    /// <summary>
    /// Obtiene los mantenimientos asociados a un arrendatario específico.
    /// </summary>
    /// <param name="arrendatarioId">Identificador del arrendatario.</param>
    Task<IEnumerable<Mantenimiento>> ListByArrendatarioIdAsync(int arrendatarioId);

    /// <summary>
    /// Guarda un nuevo mantenimiento.
    /// </summary>
    /// <param name="mantenimiento">Instancia de Mantenimiento a guardar.</param>
    Task<MantenimientoResponse> SaveAsync(Mantenimiento mantenimiento);

    /// <summary>
    /// Actualiza la información de un mantenimiento existente.
    /// </summary>
    /// <param name="mantenimientoId">Identificador del mantenimiento a actualizar.</param>
    /// <param name="mantenimiento">Instancia de Mantenimiento con la información actualizada.</param>
    Task<MantenimientoResponse> UpdateAsync(int mantenimientoId, Mantenimiento mantenimiento);

    /// <summary>
    /// Elimina un mantenimiento existente.
    /// </summary>
    /// <param name="mantenimientoId">Identificador del mantenimiento a eliminar.</param>
    Task<MantenimientoResponse> DeleteAsync(int mantenimientoId);
}