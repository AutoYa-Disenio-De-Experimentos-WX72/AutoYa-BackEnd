using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Arrendatario.
/// </summary>
public interface IArrendatarioService
{
    /// <summary>
    /// Obtiene todos los arrendatarios.
    /// </summary>
    Task<IEnumerable<Arrendatario>> ListAsync();

    /// <summary>
    /// Guarda un nuevo arrendatario.
    /// </summary>
    /// <param name="arrendatario">Instancia de Arrendatario a guardar.</param>
    Task<ArrendatarioResponse> SaveAsync(Arrendatario arrendatario);

    /// <summary>
    /// Actualiza la información de un arrendatario existente.
    /// </summary>
    /// <param name="id">Identificador del arrendatario a actualizar.</param>
    /// <param name="arrendatario">Instancia de Arrendatario con la información actualizada.</param>
    Task<ArrendatarioResponse> UpdateAsync(int id, Arrendatario arrendatario);

    /// <summary>
    /// Elimina un arrendatario existente.
    /// </summary>
    /// <param name="id">Identificador del arrendatario a eliminar.</param>
    Task<ArrendatarioResponse> DeleteAsync(int id);
}