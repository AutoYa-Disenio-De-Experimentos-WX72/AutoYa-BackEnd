namespace AutoYa_Backend.AutoYa.Resources;

public class MantenimientoResource
{
    public int Id { get; set; }
    public string TipoProblema { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string UrlImagen { get; set; }
    
    public int ArrendatarioId { get; set; }
    public int PropietarioId { get; set; }
}