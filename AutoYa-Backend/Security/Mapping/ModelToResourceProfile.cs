using AutoMapper;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Services.Communication;
using AutoYa_Backend.Security.Resources;

namespace AutoYa_Backend.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}