using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources;

namespace AutoYa_Backend.AutoYa.Mapping;

public class ResourceToModelProfile : Profile
{
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