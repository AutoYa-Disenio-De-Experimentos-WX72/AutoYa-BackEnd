using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IPropietarioService
{
    Task<IEnumerable<Propietario>> ListAsync();
    Task<PropietarioResponse> SaveAsync(Propietario propietario);
    Task<PropietarioResponse> UpdateAsync(int id, Propietario propietario);
    Task<PropietarioResponse> DeleteAsync(int id);
}