namespace AutoYa_Backend.AutoYa.Resources;

public class NotificacionResource
{
    public int Id { get; set; }
    public string Body { get; set; }
    
    public ArrendatarioResource Arrendatario { get; set; }
    public PropietarioResource Propietario { get; set; }
}