namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso utilizada para capturar información necesaria al guardar un nuevo registro de mantenimiento.
/// </summary>
public class SaveMantenimientoResource
{

    /// <summary>
    /// Tipo del problema que el mantenimiento intenta resolver.
    /// </summary>
    public string TipoProblema { get; set; }

    /// <summary>
    /// Título breve del problema de mantenimiento.
    /// </summary>
    public string Titulo { get; set; }

    /// <summary>
    /// Descripción detallada del problema de mantenimiento.
    /// </summary>
    public string Descripcion { get; set; }

    /// <summary>
    /// URL de la imagen relacionada con el mantenimiento.
    /// </summary>
    public string UrlImagen { get; set; }

    /// <summary>
    /// Identificador del arrendatario que reporta el mantenimiento.
    /// </summary>
    public int ArrendatarioId { get; set; }

    /// <summary>
    /// Identificador del propietario del vehículo sujeto a mantenimiento.
    /// </summary>
    public int PropietarioId { get; set; }
}