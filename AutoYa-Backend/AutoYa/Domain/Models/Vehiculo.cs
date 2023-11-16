namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Vehiculo
{
    public int Id { get; set; } // Primary key
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int VelocidadMax { get; set; }
    public int Consumo { get; set; }
    public string Dimensiones { get; set; }
    public int Peso { get; set; }
    public string Clase { get; set; }
    public string Transmision { get; set; }
    public int Tiempo { get; set; }
    public string TipoTiempo { get; set; } // Implementar combo box en frontend
    public int CostoAlquiler { get; set; } // Este no es el costo total del alquiler
    public string LugarRecojo { get; set; }
    public string UrlImagen { get; set; }
    public string? ContratoAlquilerPdf { get; set; }
    public string EstadoRenta { get; set; }

    // Relaciones
    // Un vehículo pertenece a solo un propietario
    public int PropietarioId { get; set; } // Foreign key
    public Propietario Propietario { get; set; }

    public int? ArrendatarioId { get; set; } // Foreign key
    public Arrendatario Arrendatario { get; set; }
    
    public int? AlquilerId { get; set; } //fk
    public Alquiler Alquiler { get; set; }

}