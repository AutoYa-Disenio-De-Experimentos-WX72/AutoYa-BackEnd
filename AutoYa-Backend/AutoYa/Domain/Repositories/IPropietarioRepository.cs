using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Propietario.
/// </summary>
public interface IPropietarioRepository
{
    /// <summary>
    /// Obtiene todos los registros de propietarios en el sistema.
    /// </summary>
    Task<IEnumerable<Propietario>> ListAsync();

    /// <summary>
    /// Agrega un nuevo propietario al sistema.
    /// </summary>
    Task AddAsync(Propietario propietario);

    /// <summary>
    /// Busca un propietario por su identificador único.
    /// </summary>
    Task<Propietario> FindByIdAsync(int propietarioId);

    /// <summary>
    /// Actualiza la información de un propietario existente.
    /// </summary>
    void Update(Propietario propietario);

    /// <summary>
    /// Elimina un propietario del sistema.
    /// </summary>
    void Remove(Propietario propietario);

    /// <summary>
    /// Busca un propietario por su dirección de correo electrónico.
    /// </summary>
    Task<Propietario> FindByEmailAsync(string email);
}