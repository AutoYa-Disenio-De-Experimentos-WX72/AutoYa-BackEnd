using System.ComponentModel.DataAnnotations;

namespace AutoYa_Backend.Security.Domain.Services.Communication;

/// <summary>
/// Clase que representa una solicitud de autenticación.
/// </summary>
public class AuthenticateRequest
{
    /// <summary>
    /// Obtiene o establece el correo electrónico requerido para la autenticación.
    /// </summary>
    [Required]
    public string Email { get; set; }
    
    /// <summary>
    /// Obtiene o establece la contraseña requerida para la autenticación.
    /// </summary>
    [Required]
    public string Password { get; set; }
}