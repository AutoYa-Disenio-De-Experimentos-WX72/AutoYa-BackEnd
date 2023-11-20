using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources;

namespace AutoYa_Backend.AutoYa.Mapping;

/// <summary>
/// Perfil AutoMapper para mapear recursos de guardado a modelos de dominio.
/// </summary>
public class ResourceToModelProfile : Profile
{
    /// <summary>
    /// Inicializa una nueva instancia del perfil de mapeo de recursos de guardado a modelos de dominio.
    /// </summary>
    public ResourceToModelProfile()
    {
        CreateMap<SaveAlquilerResource, Alquiler>();
        CreateMap<SaveArrendatarioResource, Arrendatario>();
        CreateMap<SaveMantenimientoResource, Mantenimiento>();
        CreateMap<SaveNotificacionResource, Notificacion>();
        CreateMap<SavePropietarioResource, Propietario>();
        CreateMap<SaveSolicitudResource, Solicitud>();
        CreateMap<SaveVehiculoResource, Vehiculo>();
    }
}