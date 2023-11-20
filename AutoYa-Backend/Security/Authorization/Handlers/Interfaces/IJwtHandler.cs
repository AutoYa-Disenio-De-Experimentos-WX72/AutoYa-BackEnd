using AutoYa_Backend.Security.Domain.Models;

namespace AutoYa_Backend.Security.Authorization.Handlers.Interfaces;

/// <summary>
/// Interfaz que define los métodos para manejar tokens JWT.
/// </summary>
public interface IJwtHandler
{
    /// <summary>
    /// Genera un token para un usuario.
    /// </summary>
    /// <param name="user">El usuario para el que se generará el token.</param>
    /// <returns>El token generado.</returns>
    public string GenerateToken(User user);
    
    /// <summary>
    /// Valida un token.
    /// </summary>
    /// <param name="token">El token a validar.</param>
    /// <returns>El ID del usuario si el token es válido, null en caso contrario.</returns>
    public int? ValidateToken(string token);
}