using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class MantenimientoResponse : BaseResponse<Mantenimiento>
{
    public MantenimientoResponse(string message) : base(message)
    {
    }

    public MantenimientoResponse(Mantenimiento resource) : base(resource)
    {
    }
}