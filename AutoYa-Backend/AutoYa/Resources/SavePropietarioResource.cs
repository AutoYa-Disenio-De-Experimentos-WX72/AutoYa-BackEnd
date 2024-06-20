namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso para guardar información sobre un propietario. 
/// Utilizada para capturar datos que serán almacenados en la base de datos.
/// </summary>
public class SavePropietarioResource
{
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
    /// Contraseña de acceso para el propietario. Debe ser manejada de forma segura.
    /// </summary>
    public string Contrasenia { get; set; }
}