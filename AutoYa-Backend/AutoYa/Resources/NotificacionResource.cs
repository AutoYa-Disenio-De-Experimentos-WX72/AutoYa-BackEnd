namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso para la transferencia de datos de notificaciones.
/// Contiene las propiedades que representan la información esencial de una notificación.
/// </summary>

public class NotificacionResource
{

    /// <summary>
    /// Identificador único de la notificación.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Cuerpo de la notificación con el mensaje a ser transmitido al usuario.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Identificador del propietario asociado a la notificación.
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Identificador del arrendatario asociado a la notificación.
    /// </summary>
    public int ArrendatarioId { get; set; }
}