namespace AutoYa_Backend.AutoYa.Resources;

public class AlquilerResource
{
    public int Id { get; set; }
    public string Estado { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int CostoTotal { get; set; }
    
    public VehiculoResource Vehiculo { get; set; }
    public PropietarioResource Propietario { get; set; }
    public ArrendatarioResource Arrendatario { get; set; }
    public SolicitudResource Solicitud { get; set; }
}