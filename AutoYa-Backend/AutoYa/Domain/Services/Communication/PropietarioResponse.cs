using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class PropietarioResponse : BaseResponse<Propietario>
{
    public PropietarioResponse(string message) : base(message)
    {
    }

    public PropietarioResponse(Propietario resource) : base(resource)
    {
    }
}