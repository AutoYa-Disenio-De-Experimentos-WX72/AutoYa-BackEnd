namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
/// Representa un registro de mantenimiento asociado a un vehículo y reportado por un arrendatario o propietario.
/// </summary>
public class Mantenimiento
{
    /// <summary>
    /// Obtiene o establece el identificador del mantenimiento (clave primaria).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el tipo de problema reportado durante el mantenimiento.
    /// </summary>
    public string TipoProblema { get; set; }

    /// <summary>
    /// Obtiene o establece el título del mantenimiento para identificar el problema.
    /// </summary>
    public string Titulo { get; set; }

    /// <summary>
    /// Obtiene o establece una descripción detallada del problema reportado durante el mantenimiento.
    /// </summary>
    public string Descripcion { get; set; }

    /// <summary>
    /// Obtiene o establece la URL de la imagen que ilustra el problema reportado durante el mantenimiento.
    /// </summary>
    public string UrlImagen { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del arrendatario que reportó el mantenimiento (clave foránea).
    /// </summary>
    public int ArrendatarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Arrendatario que reportó el mantenimiento.
    /// </summary>
    public Arrendatario Arrendatario { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del propietario asociado al mantenimiento (clave foránea).
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Propietario asociado al mantenimiento.
    /// </summary>
    public Propietario Propietario { get; set; }
}