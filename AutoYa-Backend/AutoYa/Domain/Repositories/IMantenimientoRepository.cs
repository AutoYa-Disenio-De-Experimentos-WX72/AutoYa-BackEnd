using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Mantenimiento.
/// </summary>
public interface IMantenimientoRepository
{
    /// <summary>
    /// Obtiene todos los registros de mantenimiento en el sistema.
    /// </summary>
    Task<IEnumerable<Mantenimiento>> ListAsync();

    /// <summary>
    /// Agrega un nuevo registro de mantenimiento al sistema.
    /// </summary>
    Task AddAsync(Mantenimiento mantenimiento);

    /// <summary>
    /// Busca un registro de mantenimiento por su identificador único.
    /// </summary>
    Task<Mantenimiento> FindByIdAsync(int mantenimientoId);

    /// <summary>
    /// Actualiza la información de un registro de mantenimiento existente.
    /// </summary>
    void Update(Mantenimiento mantenimiento);

    /// <summary>
    /// Elimina un registro de mantenimiento del sistema.
    /// </summary>
    void Remove(Mantenimiento mantenimiento);

    /// <summary>
    /// Busca registros de mantenimiento asociados a un arrendatario específico.
    /// </summary>
    Task<IEnumerable<Mantenimiento>> FindByArrendatarioIdAsync(int arrendatarioId);

    /// <summary>
    /// Busca registros de mantenimiento asociados a un propietario específico.
    /// </summary>
    Task<IEnumerable<Mantenimiento>> FindByPropietarioIdAsync(int propietarioId);
}