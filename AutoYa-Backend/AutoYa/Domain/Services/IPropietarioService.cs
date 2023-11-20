using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

/// <summary>
/// Interfaz que define las operaciones relacionadas con la entidad Propietario.
/// </summary>
public interface IPropietarioService
{
    /// <summary>
    /// Obtiene todos los propietarios.
    /// </summary>
    Task<IEnumerable<Propietario>> ListAsync();

    /// <summary>
    /// Guarda un nuevo propietario.
    /// </summary>
    /// <param name="propietario">Instancia de Propietario a guardar.</param>
    Task<PropietarioResponse> SaveAsync(Propietario propietario);

    /// <summary>
    /// Actualiza la información de un propietario existente.
    /// </summary>
    /// <param name="id">Identificador del propietario a actualizar.</param>
    /// <param name="propietario">Instancia de Propietario con la información actualizada.</param>
    Task<PropietarioResponse> UpdateAsync(int id, Propietario propietario);

    /// <summary>
    /// Elimina un propietario existente.
    /// </summary>
    /// <param name="id">Identificador del propietario a eliminar.</param>
    Task<PropietarioResponse> DeleteAsync(int id);
}