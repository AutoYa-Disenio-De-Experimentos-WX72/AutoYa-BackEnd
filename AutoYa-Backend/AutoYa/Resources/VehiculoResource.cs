namespace AutoYa_Backend.AutoYa.Resources;

public class VehiculoResource
{
    public int Id { get; set; }
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
    public PropietarioResource Propietario { get; set; }
    public ArrendatarioResource? Arrendatario { get; set; }
    public AlquilerResource? Alquiler { get; set; }
}