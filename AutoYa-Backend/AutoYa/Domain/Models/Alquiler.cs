namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Alquiler
{
    public int Id { get; set; } //primary key
    public string Estado { get; set; }
    public DateTime Fecha_inicio { get; set; }
    public DateTime Fecha_fin { get; set; }
    public int Costo_total { get; set; } //tiempo de alquiler del vehículo X precio de alquiler durante un tiempo
    
    //Relaciones
    //un alquiler solo puede tener un vehículo, un propietario y un arrendatario
    public int VehiculoId { get; set; } //fk
    public Vehiculo Vehiculo { get; set; }
    
    public int PropietarioId { get; set; } //fk
    public Propietario Propietario { get; set; }
    
    public int ArrendatarioId { get; set; } //fk
    public Arrendatario Arrendatario { get; set; }
    
    public List<Solicitud> Solicitudes { get; set; }
}