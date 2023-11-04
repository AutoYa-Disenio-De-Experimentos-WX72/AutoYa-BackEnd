using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IArrendatarioService
{
    Task<IEnumerable<Arrendatario>> ListAsync();
    Task<ArrendatarioResponse> SaveAsync(Arrendatario arrendatario);
    Task<ArrendatarioResponse> UpdateAsync(int id, Arrendatario arrendatario);
    Task<ArrendatarioResponse> DeleteAsync(int id);
}