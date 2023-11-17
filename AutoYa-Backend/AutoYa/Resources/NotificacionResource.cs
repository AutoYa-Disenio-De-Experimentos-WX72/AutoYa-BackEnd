namespace AutoYa_Backend.AutoYa.Resources;

public class NotificacionResource
{
    public int Id { get; set; }
    public string Body { get; set; }
    
    public int PropietarioId { get; set; }
    public int ArrendatarioId { get; set; }
}