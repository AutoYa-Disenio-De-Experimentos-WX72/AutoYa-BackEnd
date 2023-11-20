namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
/// Representa un vehículo disponible para alquiler en el sistema.
/// </summary>
public class Vehiculo
{
    /// <summary>
    /// Obtiene o establece el identificador del vehículo (clave primaria).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece la marca del vehículo.
    /// </summary>
    public string Marca { get; set; }

    /// <summary>
    /// Obtiene o establece el modelo del vehículo.
    /// </summary>
    public string Modelo { get; set; }

    /// <summary>
    /// Obtiene o establece la velocidad máxima del vehículo.
    /// </summary>
    public int VelocidadMax { get; set; }

    /// <summary>
    /// Obtiene o establece el consumo de combustible del vehículo.
    /// </summary>
    public int Consumo { get; set; }

    /// <summary>
    /// Obtiene o establece las dimensiones del vehículo.
    /// </summary>
    public string Dimensiones { get; set; }

    /// <summary>
    /// Obtiene o establece el peso del vehículo.
    /// </summary>
    public int Peso { get; set; }

    /// <summary>
    /// Obtiene o establece la clase del vehículo.
    /// </summary>
    public string Clase { get; set; }

    /// <summary>
    /// Obtiene o establece el tipo de transmisión del vehículo.
    /// </summary>
    public string Transmision { get; set; }

    /// <summary>
    /// Obtiene o establece el tiempo de alquiler del vehículo.
    /// </summary>
    public int Tiempo { get; set; }

    /// <summary>
    /// Obtiene o establece el tipo de tiempo para el alquiler del vehículo.
    /// </summary>
    public string TipoTiempo { get; set; }

    /// <summary>
    /// Obtiene o establece el costo de alquiler por unidad de tiempo del vehículo.
    /// </summary>
    public int CostoAlquiler { get; set; }

    /// <summary>
    /// Obtiene o establece el lugar de recojo del vehículo.
    /// </summary>
    public string LugarRecojo { get; set; }

    /// <summary>
    /// Obtiene o establece la URL de la imagen del vehículo.
    /// </summary>
    public string UrlImagen { get; set; }

    /// <summary>
    /// Obtiene o establece la ruta o identificador del contrato de alquiler en formato PDF.
    /// </summary>
    public string? ContratoAlquilerPdf { get; set; }

    /// <summary>
    /// Obtiene o establece el estado de renta del vehículo.
    /// </summary>
    public string EstadoRenta { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del propietario al cual pertenece el vehículo (clave foránea).
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Propietario al cual pertenece el vehículo.
    /// </summary>
    public Propietario Propietario { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del arrendatario que tiene actualmente el vehículo (clave foránea).
    /// </summary>
    public int? ArrendatarioId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Arrendatario que tiene actualmente el vehículo.
    /// </summary>
    public Arrendatario Arrendatario { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del alquiler asociado al vehículo (clave foránea).
    /// </summary>
    public int? AlquilerId { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia al objeto Alquiler asociado al vehículo.
    /// </summary>
    public Alquiler Alquiler { get; set; }
}