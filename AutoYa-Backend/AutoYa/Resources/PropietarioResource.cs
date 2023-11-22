namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso que representa a un propietario para el intercambio de datos en la aplicación.
/// </summary>
public class PropietarioResource
{

    /// <summary>
    /// Identificador único para el propietario.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombres del propietario.
    /// </summary>
    public string Nombres { get; set; }

    /// <summary>
    /// Apellidos del propietario.
    /// </summary>
    public string Apellidos { get; set; }


    /// <summary>
    /// Fecha de nacimiento del propietario.
    /// </summary>
    public string FechaNacimiento { get; set; }

    /// <summary>
    /// Número de teléfono del propietario.
    /// </summary>
    public int Telefono { get; set; }

    /// <summary>
    /// Correo electrónico del propietario.
    /// </summary>
    public string Correo { get; set; }

    /// <summary>
    /// Contraseña de la cuenta del propietario. Se debe manejar con seguridad y nunca exponer en texto plano.
    /// </summary>
    public string Contrasenia { get; set; }
}