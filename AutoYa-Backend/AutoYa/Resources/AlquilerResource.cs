namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Recurso de representación de un alquiler para exponer datos a través de la API.
/// </summary>

public class AlquilerResource
{

    /// <summary>
    /// Identificador único del alquiler.
    /// </summary>
    
    public int Id { get; set; }

    /// <summary>
    /// Estado actual del alquiler.
    /// </summary>
    
    public string Estado { get; set; }

    /// <summary>
    /// Fecha y hora de inicio del alquiler.
    /// </summary>
    
    public DateTime Fecha_inicio { get; set; }

    /// <summary>
    /// Fecha y hora de finalización del alquiler.
    /// </summary>
    
    public DateTime Fecha_fin { get; set; }

    /// <summary>
    /// Costo total del alquiler.
    /// </summary>
    
    public int Costo_total { get; set; }
    
    /// <summary>
    /// Identificador del propietario del vehículo alquilado.
    /// </summary>
    
    public int PropietarioId { get; set; }

    /// <summary>
    /// Identificador del arrendatario que realiza el alquiler.
    /// </summary>
    
    public int ArrendatarioId { get; set; }

    /// <summary>
    /// Identificador del vehículo que está siendo alquilado.
    /// </summary>
    
    public int VehiculoId { get; set; }
}