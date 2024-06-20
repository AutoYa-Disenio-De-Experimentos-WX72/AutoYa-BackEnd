namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
/// Representa un alquiler de vehículo.
/// </summary>
public class Alquiler
{
    /// <summary>
    /// Obtiene o establece el identificador del alquiler (clave primaria).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el estado del alquiler.
    /// </summary>
    public string Estado { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha de inicio del alquiler.
    /// </summary>
    public string Fecha_inicio { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha de fin del alquiler.
    /// </summary>
    public string Fecha_fin { get; set; }

    /// <summary>
    /// Obtiene o establece el costo total del alquiler, calculado como el tiempo de alquiler multiplicado por el precio de alquiler por unidad de tiempo.
    /// </summary>
    public int Costo_total { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del vehículo asociado al alquiler (clave foránea).
    /// </summary>
    public int VehiculoId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Vehiculo asociado al alquiler.
    /// </summary>
    public Vehiculo Vehiculo { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del propietario asociado al alquiler (clave foránea).
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Propietario asociado al alquiler.
    /// </summary>
    public Propietario Propietario { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del arrendatario asociado al alquiler (clave foránea).
    /// </summary>
    public int ArrendatarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Arrendatario asociado al alquiler.
    /// </summary>
    public Arrendatario Arrendatario { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de solicitudes asociadas al alquiler.
    /// </summary>
    public List<Solicitud> Solicitudes { get; set; }
}