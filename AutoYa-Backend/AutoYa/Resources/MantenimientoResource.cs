namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso para la transferencia de datos de mantenimiento asociados con vehículos.
/// </summary>

public class MantenimientoResource
{

    /// <summary>
    /// Identificador único del registro de mantenimiento.
    /// </summary>
    
    public int Id { get; set; }

    /// <summary>
    /// Tipo de problema al que se dirige el mantenimiento.
    /// </summary>
    
    public string TipoProblema { get; set; }

    /// <summary>
    /// Título del problema de mantenimiento.
    /// </summary>
    
    public string Titulo { get; set; }

    /// <summary>
    /// Descripción detallada del problema de mantenimiento.
    /// </summary>
    
    public string Descripcion { get; set; }

    /// <summary>
    /// URL de una imagen que representa visualmente el problema de mantenimiento.
    /// </summary>
    
    public string UrlImagen { get; set; }

    /// <summary>
    /// Identificador del arrendatario asociado con el registro de mantenimiento.
    /// </summary>
    
    public int ArrendatarioId { get; set; }

    /// <summary>
    /// Identificador del propietario asociado con el registro de mantenimiento.
    /// </summary>
    
    public int PropietarioId { get; set; }
}