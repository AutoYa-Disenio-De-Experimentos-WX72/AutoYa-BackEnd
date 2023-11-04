namespace AutoYa_Backend.AutoYa.Resources;

public class SaveAlquilerResource
{
    public string Estado { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int CostoTotal { get; set; }
    public int VehiculoId { get; set; }
    public int PropietarioId { get; set; }
    public int ArrendatarioId { get; set; }
    public int SolicitudId { get; set; }
}