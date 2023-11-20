namespace AutoYa_Backend.Security.Resources;

/// <summary>
/// Clase que representa un recurso de usuario.
/// </summary>
public class UserResource
{
    /// <summary>
    /// Obtiene o establece el ID del recurso de usuario.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Obtiene o establece el nombre del recurso de usuario.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el apellido del recurso de usuario.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el correo electrónico del recurso de usuario.
    /// </summary>
    public string Email { get; set; } 
}