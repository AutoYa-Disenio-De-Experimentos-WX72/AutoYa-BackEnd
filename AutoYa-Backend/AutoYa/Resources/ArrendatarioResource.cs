namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso para la transferencia de datos de un arrendatario.
/// Contiene las propiedades que representan la información pública de un arrendatario.
/// </summary>

public class ArrendatarioResource
{
    /// <summary>
    /// Identificador único del arrendatario.
    /// </summary>
    
    public int Id { get; set; }

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
    /// Ruta o enlace al documento PDF de antecedentes penales del arrendatario, si está disponible.
    /// </summary>
    
    public string? AntecedentesPenalesPdf { get; set; }

    /// <summary>
    /// Contraseña de la cuenta del arrendatario. Debe ser almacenada de forma segura y nunca expuesta en texto claro.
    /// </summary>
    
    public string Contrasenia { get; set; }
}

