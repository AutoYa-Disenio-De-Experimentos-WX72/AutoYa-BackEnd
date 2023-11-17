namespace AutoYa_Backend.AutoYa.Resources;

public class SaveAlquilerResource
{
    public string Estado { get; set; }
    public DateTime Fecha_inicio { get; set; }
    public DateTime Fecha_fin { get; set; }
    public int Costo_total { get; set; }
    
    public int VehiculoId { get; set; }
    public int PropietarioId { get; set; }
    public int ArrendatarioId { get; set; }
}