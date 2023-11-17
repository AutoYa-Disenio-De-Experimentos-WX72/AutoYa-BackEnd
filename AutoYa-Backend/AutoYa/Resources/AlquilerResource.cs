namespace AutoYa_Backend.AutoYa.Resources;

public class AlquilerResource
{
    public int Id { get; set; }
    public string Estado { get; set; }
    public DateTime Fecha_inicio { get; set; }
    public DateTime Fecha_fin { get; set; }
    public int Costo_total { get; set; }
    
    public int PropietarioId { get; set; }
    public int ArrendatarioId { get; set; }
    public int VehiculoId { get; set; }
}