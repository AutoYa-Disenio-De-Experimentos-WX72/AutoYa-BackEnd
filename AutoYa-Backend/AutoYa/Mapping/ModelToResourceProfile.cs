using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources;

namespace AutoYa_Backend.AutoYa.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Alquiler, AlquilerResource>();
        CreateMap<Arrendatario, ArrendatarioResource>();
        CreateMap<Mantenimiento, MantenimientoResource>();
        CreateMap<Notificacion, NotificacionResource>();
        CreateMap<Propietario, PropietarioResource>();
        CreateMap<Solicitud, SolicitudResource>();
        CreateMap<Vehiculo, VehiculoResource>()
            .ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.Propietario))
            .ForMember(dest => dest.Arrendatario, opt => opt.MapFrom(src => src.Arrendatario))
            .ForMember(dest => dest.Alquiler, opt => opt.MapFrom(src => src.Alquiler));
    }
}