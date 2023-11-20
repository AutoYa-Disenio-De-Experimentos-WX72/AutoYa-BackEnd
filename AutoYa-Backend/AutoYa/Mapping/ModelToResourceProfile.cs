using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources;

namespace AutoYa_Backend.AutoYa.Mapping;

/// <summary>
/// Perfil AutoMapper para mapear modelos de dominio a recursos.
/// </summary>
public class ModelToResourceProfile : Profile
{
    /// <summary>
    /// Inicializa una nueva instancia del perfil de mapeo de modelos a recursos.
    /// </summary>
    public ModelToResourceProfile()
    {
        CreateMap<Alquiler, AlquilerResource>();
        CreateMap<Arrendatario, ArrendatarioResource>();
        CreateMap<Mantenimiento, MantenimientoResource>();
        CreateMap<Notificacion, NotificacionResource>();
        CreateMap<Propietario, PropietarioResource>();
        CreateMap<Solicitud, SolicitudResource>();
            
        // Mapeo de Vehiculo a VehiculoResource con inclusión de miembros.
        CreateMap<Vehiculo, VehiculoResource>()
            .ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.Propietario))
            .ForMember(dest => dest.Arrendatario, opt => opt.MapFrom(src => src.Arrendatario))
            .ForMember(dest => dest.Alquiler, opt => opt.MapFrom(src => src.Alquiler));
    }
}