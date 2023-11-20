using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Services.Communication;

namespace AutoYa_Backend.Security.Domain.Services;

/// <summary>
/// Interfaz que define los métodos para un servicio de usuarios.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Autentica un usuario.
    /// </summary>
    /// <param name="model">El modelo de autenticación.</param>
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    
    
    /// <summary>
    /// Obtiene una lista de todos los usuarios de forma asíncrona.
    /// </summary>
    Task<IEnumerable<User>> ListAsync();
    
    /// <summary>
    /// Obtiene un usuario por su ID de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    Task<User> GetByIdAsync(int id);
    
    /// <summary>
    /// Registra un nuevo usuario de forma asíncrona.
    /// </summary>
    /// <param name="model">El modelo de registro.</param>
    Task RegisterAsync(RegisterRequest model);
    
    /// <summary>
    /// Actualiza un usuario de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    /// <param name="model">El modelo de actualización.</param>
    Task UpdateAsync(int id, UpdateRequest model);
    
    /// <summary>
    /// Elimina un usuario de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    Task DeleteAsync(int id);
}