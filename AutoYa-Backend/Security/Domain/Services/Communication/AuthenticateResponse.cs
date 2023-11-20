namespace AutoYa_Backend.Security.Domain.Services.Communication;

/// <summary>
/// Clase que representa una respuesta de autenticación.
/// </summary>
public class AuthenticateResponse
{
    /// <summary>
    /// Obtiene o establece el ID del usuario autenticado.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Obtiene o establece el nombre del usuario autenticado.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el apellido del usuario autenticado.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el correo electrónico del usuario autenticado.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Obtiene o establece el token de autenticación del usuario.
    /// </summary>
    public string Token { get; set; }

}