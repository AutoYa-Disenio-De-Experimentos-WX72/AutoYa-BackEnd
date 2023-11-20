namespace AutoYa_Backend.AutoYa.Resources;

/// <summary>
/// Clase de recurso que representa un vehículo dentro de la aplicación.
/// Se utiliza para transferir información detallada de vehículos entre las capas de la aplicación.
/// </summary>
public class VehiculoResource
{

    /// <summary>
    /// Identificador único del vehículo.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Marca del vehículo.
    /// </summary>
    public string Marca { get; set; }

    /// <summary>
    /// Modelo del vehículo.
    /// </summary>
    public string Modelo { get; set; }

    /// <summary>
    /// Velocidad máxima que el vehículo puede alcanzar.
    /// </summary>
    public int VelocidadMax { get; set; }

    /// <summary>
    /// Consumo de combustible del vehículo por cada cien kilómetros.
    /// </summary>
    public int Consumo { get; set; }

    /// <summary>
    /// Dimensiones físicas del vehículo.
    /// </summary>
    public string Dimensiones { get; set; }

    /// <summary>
    /// Peso del vehículo.
    /// </summary>
    public int Peso { get; set; }

    /// <summary>
    /// Clase o categoría del vehículo.
    /// </summary>
    public string Clase { get; set; }

    /// <summary>
    /// Tipo de transmisión del vehículo.
    /// </summary>
    public string Transmision { get; set; }

    /// <summary>
    /// Tiempo de uso o antigüedad del vehículo.
    /// </summary>
    public int Tiempo { get; set; }

    /// <summary>
    /// Unidad de medida del tiempo de uso o antigüedad del vehículo.
    /// </summary>
    /// <remarks>Se debe implementar un combo box en el frontend para seleccionar esta unidad.</remarks>
    public string TipoTiempo { get; set; } // Implementar combo box en frontend

    /// <summary>
    /// Costo base para el alquiler del vehículo, sin incluir otros cargos o seguros.
    /// </summary>
    /// <remarks>Este no es el costo total del alquiler.</remarks>
    public int CostoAlquiler { get; set; } // Este no es el costo total del alquiler

    /// <summary>
    /// Lugar designado para recoger el vehículo al inicio del alquiler.
    /// </summary>
    public string LugarRecojo { get; set; }

    /// <summary>
    /// URL de la imagen representativa del vehículo.
    /// </summary>
    public string UrlImagen { get; set; }

    /// <summary>
    /// Ruta al archivo PDF del contrato de alquiler del vehículo.
    /// </summary>
    public string? ContratoAlquilerPdf { get; set; }

    /// <summary>
    /// Estado actual del vehículo con respecto a su disponibilidad para el alquiler.
    /// </summary>
    public string EstadoRenta { get; set; }

    /// <summary>
    /// Información del propietario del vehículo.
    /// </summary>
    public PropietarioResource Propietario { get; set; }

    /// <summary>
    /// Información del arrendatario actual del vehículo, si aplica.
    /// </summary>
    public ArrendatarioResource? Arrendatario { get; set; }

    /// <summary>
    /// Información del alquiler actual asociado al vehículo, si aplica.
    /// </summary>
    public AlquilerResource? Alquiler { get; set; }
}