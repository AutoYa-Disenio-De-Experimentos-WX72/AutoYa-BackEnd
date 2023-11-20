namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso que representa una solicitud dentro de la aplicación.
/// Se utiliza para transferir datos de solicitudes entre las capas de la aplicación.
/// </summary>
public class SolicitudResource
{

    /// <summary>
    /// Identificador único de la solicitud.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Cuerpo de la solicitud que contiene el mensaje o la información principal de la misma.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Identificador del alquiler asociado a la solicitud.
    /// </summary>
    public int AlquilerId { get; set; }
}