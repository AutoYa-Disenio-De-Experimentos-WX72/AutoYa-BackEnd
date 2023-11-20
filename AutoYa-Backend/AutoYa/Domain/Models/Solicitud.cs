namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
/// Representa una solicitud relacionada con un alquiler en el sistema.
/// </summary>
public class Solicitud
{
    /// <summary>
    /// Obtiene o establece el identificador de la solicitud (clave primaria).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el contenido o mensaje de la solicitud.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del alquiler al cual está asociada la solicitud (clave foránea).
    /// </summary>
    public int AlquilerId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Alquiler al cual está asociada la solicitud.
    /// </summary>
    public Alquiler Alquiler { get; set; }
}