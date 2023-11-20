namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso utilizada para guardar la información de un alquiler.
/// Contiene las propiedades necesarias para crear o actualizar un alquiler.
/// </summary>
public class SaveAlquilerResource
{

    /// <summary>
    /// Estado actual del alquiler.
    /// </summary>
    public string Estado { get; set; }

    /// <summary>
    /// Fecha y hora de inicio del periodo de alquiler.
    /// </summary>
    public DateTime Fecha_inicio { get; set; }

    /// <summary>
    /// Fecha y hora de fin del periodo de alquiler.
    /// </summary>
    public DateTime Fecha_fin { get; set; }

    /// <summary>
    /// Costo total asociado al alquiler.
    /// </summary>
    public int Costo_total { get; set; }

    /// <summary>
    /// Identificador del vehículo que se alquila.
    /// </summary>
    public int VehiculoId { get; set; }

    /// <summary>
    /// Identificador del propietario del vehículo.
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Identificador del arrendatario que realiza el alquiler.
    /// </summary>
    public int ArrendatarioId { get; set; }
}