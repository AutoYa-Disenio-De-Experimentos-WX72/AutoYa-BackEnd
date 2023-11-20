namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso utilizada para guardar la información necesaria al crear una nueva notificación.
/// </summary>
public class SaveNotificacionResource
{
    /// <summary>
    /// Contenido o cuerpo de la notificación que se va a enviar.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Identificador del propietario a quien va dirigida o que emite la notificación.
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Identificador del arrendatario a quien va dirigida o que emite la notificación.
    /// </summary>
    public int ArrendatarioId { get; set; }
}