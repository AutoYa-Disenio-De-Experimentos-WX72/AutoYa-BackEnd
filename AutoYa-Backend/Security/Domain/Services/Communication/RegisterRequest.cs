using System.ComponentModel.DataAnnotations;

namespace AutoYa_Backend.Security.Domain.Services.Communication;

/// <summary>
/// Clase que representa una solicitud de registro.
/// </summary>
public class RegisterRequest
{
    /// <summary>
    /// Obtiene o establece el nombre requerido para el registro.
    /// </summary>
    [Required]
    public string FirstName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el apellido requerido para el registro.
    /// </summary>
    [Required]
    public string LastName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el correo electrónico requerido para el registro.
    /// </summary>
    [Required]
    public string Email { get; set; }
    
    /// <summary>
    /// Obtiene o establece la contraseña requerida para el registro.
    /// </summary>
    [Required]
    public string Password { get; set; }
}