namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso para guardar información sobre una solicitud.
/// Utilizada para capturar datos que serán almacenados en la base de datos.
/// </summary>
public class SaveSolicitudResource
{
    /// <summary>
    /// Contenido o cuerpo de la solicitud.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Identificador del alquiler asociado con la solicitud.
    /// </summary>
    public int AlquilerId { get; set; }
}