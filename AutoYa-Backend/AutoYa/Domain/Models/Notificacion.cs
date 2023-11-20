namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
/// Representa una notificación que puede contener información sobre solicitudes o mensajes de mantenimiento.
/// </summary>
public class Notificacion
{
    /// <summary>
    /// Obtiene o establece el identificador de la notificación (clave primaria).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el contenido del mensaje de la notificación.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del propietario al cual está dirigida la notificación (clave foránea).
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Propietario al cual está dirigida la notificación.
    /// </summary>
    public Propietario Propietario { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del arrendatario que envió la notificación (clave foránea).
    /// </summary>
    public int ArrendatarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Arrendatario que envió la notificación.
    /// </summary>
    public Arrendatario Arrendatario { get; set; }
}