namespace AutoYa_Backend.AutoYa.Resources;

public class SaveVehiculoResource
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int VelocidadMax { get; set; }
    public int Consumo { get; set; }
    public string Dimensiones { get; set; }
    public int Peso { get; set; }
    public string Clase { get; set; }
    public string Transmision { get; set; }
    public int Tiempo { get; set; }
    public string TipoTiempo { get; set; }
    public int CostoAlquiler { get; set; }
    public string LugarRecojo { get; set; }
    public string UrlImagen { get; set; }
    public byte[] ContratoAlquilerPdf { get; set; }
    public int PropietarioId { get; set; }
    public int ArrendatarioId { get; set; }
    public int AlquilerId { get; set; }
}