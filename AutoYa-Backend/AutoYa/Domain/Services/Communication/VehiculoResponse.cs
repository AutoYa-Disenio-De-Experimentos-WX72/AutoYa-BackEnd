using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class VehiculoResponse : BaseResponse<Vehiculo>
{
    public VehiculoResponse(string message) : base(message)
    {
    }

    public VehiculoResponse(Vehiculo resource) : base(resource)
    {
    }
}