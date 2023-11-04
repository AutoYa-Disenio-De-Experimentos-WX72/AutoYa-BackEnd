namespace AutoYa_Backend.AutoYa.Resources;

public class SolicitudResource
{
    public int Id { get; set; }
    public string Body { get; set; }
    
    public AlquilerResource Alquiler { get; set; }
}