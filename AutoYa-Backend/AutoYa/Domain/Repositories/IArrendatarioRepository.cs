using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

/// <summary>
/// Interfaz que define operaciones de acceso a datos para la entidad Arrendatario.
/// </summary>
public interface IArrendatarioRepository
{
    /// <summary>
    /// Obtiene todos los arrendatarios en el sistema.
    /// </summary>
    Task<IEnumerable<Arrendatario>> ListAsync();

    /// <summary>
    /// Agrega un nuevo arrendatario al sistema.
    /// </summary>
    Task AddAsync(Arrendatario arrendatario);

    /// <summary>
    /// Busca un arrendatario por su identificador único.
    /// </summary>
    Task<Arrendatario> FindByIdAsync(int? arrendatarioId);

    /// <summary>
    /// Busca un arrendatario por su dirección de correo electrónico.
    /// </summary>
    Task<Arrendatario> FindByEmailAsync(string email);

    /// <summary>
    /// Actualiza la información de un arrendatario existente.
    /// </summary>
    void Update(Arrendatario arrendatario);

    /// <summary>
    /// Elimina un arrendatario del sistema.
    /// </summary>
    void Remove(Arrendatario arrendatario);
}