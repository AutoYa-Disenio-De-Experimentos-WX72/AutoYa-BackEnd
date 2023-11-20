namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso utilizada para guardar o enviar información de un arrendatario.
/// Contiene las propiedades necesarias para crear o actualizar los datos de un arrendatario.
/// </summary>
public class SaveArrendatarioResource
{

    /// <summary>
    /// Nombres del arrendatario.
    /// </summary>
    public string Nombres { get; set; }

    /// <summary>
    /// Apellidos del arrendatario.
    /// </summary>
    public string Apellidos { get; set; }

    /// <summary>
    /// Fecha de nacimiento del arrendatario.
    /// </summary>
    public DateTime FechaNacimiento { get; set; }

    /// <summary>
    /// Número de teléfono del arrendatario.
    /// </summary>
    public int Telefono { get; set; }

    /// <summary>
    /// Correo electrónico del arrendatario.
    /// </summary>
    public string Correo { get; set; }

    /// <summary>
    /// Ruta al archivo PDF de antecedentes penales del arrendatario. 
    /// </summary>
    /// <remarks>Este campo está destinado a cambiar a IFormFile para permitir la carga de archivos.</remarks>
    public string? AntecedentesPenalesPdf { get; set; } //cambiar el string a IFormFile
    
    /// <summary>
    /// Contraseña para la cuenta del arrendatario. Debe ser manejada de manera segura.
    /// </summary>
    public string Contrasenia { get; set; }
}