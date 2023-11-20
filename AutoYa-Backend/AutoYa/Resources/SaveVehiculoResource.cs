namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso utilizada para capturar la información necesaria al guardar un nuevo vehículo o actualizar uno existente.
/// </summary>
public class SaveVehiculoResource
{

    /// <summary>
    /// Marca del vehículo.
    /// </summary>
    public string Marca { get; set; }

    /// <summary>
    /// Modelo del vehículo.
    /// </summary>
    public string Modelo { get; set; }

    /// <summary>
    /// Velocidad máxima que puede alcanzar el vehículo, generalmente medida en kilómetros por hora (km/h).
    /// </summary>
    public int VelocidadMax { get; set; }

    /// <summary>
    /// Consumo de combustible del vehículo, generalmente medido en litros por 100 kilómetros (l/100km).
    /// </summary>
    public int Consumo { get; set; }

    /// <summary>
    /// Dimensiones del vehículo.
    /// </summary>
    public string Dimensiones { get; set; }

    /// <summary>
    /// Peso del vehículo, generalmente medido en kilogramos (kg).
    /// </summary>
    public int Peso { get; set; }

    /// <summary>
    /// Clase del vehículo.
    /// </summary>
    public string Clase { get; set; }

    /// <summary>
    /// Tipo de transmisión del vehículo (manual, automática, etc.).
    /// </summary>
    public string Transmision { get; set; }

    /// <summary>
    /// Tiempo de uso o antigüedad del vehículo, cuya unidad se especifica en TipoTiempo.
    /// </summary>
    public int Tiempo { get; set; }

    /// <summary>
    /// Unidad de tiempo para la antigüedad o uso del vehículo (años, meses, días).
    /// </summary>
    public string TipoTiempo { get; set; }

    /// <summary>
    /// Costo de alquiler del vehículo.
    /// </summary>
    public int CostoAlquiler { get; set; }

    /// <summary>
    /// Lugar acordado para la recolección del vehículo.
    /// </summary>
    public string LugarRecojo { get; set; }

    /// <summary>
    /// URL de la imagen del vehículo.
    /// </summary>

    public string UrlImagen { get; set; }

    /// <summary>
    /// Ruta al archivo PDF del contrato de alquiler del vehículo.
    /// </summary>
    public string? ContratoAlquilerPdf { get; set; }

    /// <summary>
    /// Estado actual de la renta del vehículo (disponible, alquilado, en mantenimiento, etc.).
    /// </summary>
    public string EstadoRenta { get; set; }

    /// <summary>
    /// Identificador del propietario del vehículo.
    /// </summary>
    public int PropietarioId { get; set; }

    /// <summary>
    /// Identificador del arrendatario actual del vehículo, si aplica.
    /// </summary>
    public int? ArrendatarioId { get; set; }

    /// <summary>
    /// Identificador del alquiler asociado al vehículo, si aplica.
    /// </summary>
    public int? AlquilerId { get; set; }
}