using System.Text.Json.Serialization;

namespace AutoYa_Backend.Security.Domain.Models;

/// <summary>
/// Clase que representa un usuario.
/// </summary>
public class User
{
    /// <summary>
    /// Obtiene o establece el ID del usuario.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Obtiene o establece el nombre del usuario.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el apellido del usuario.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Obtiene o establece el correo electrónico del usuario.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Obtiene o establece el hash de la contraseña del usuario.
    /// Este campo se ignora al serializar el objeto.
    /// </summary>
    [JsonIgnore]
    public string PasswordHash { get; set; }
}