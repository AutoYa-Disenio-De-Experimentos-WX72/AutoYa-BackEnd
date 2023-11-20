namespace AutoYa_Backend.Security.Domain.Services.Communication;

/// <summary>
/// Clase que representa una solicitud de actualización.
/// </summary>
public class UpdateRequest
{
    /// <summary>
    /// Obtiene o establece el nombre para la actualización.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el apellido para la actualización.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el correo electrónico para la actualización.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Obtiene o establece la contraseña para la actualización.
    /// </summary>
    public string Password { get; set; }
}