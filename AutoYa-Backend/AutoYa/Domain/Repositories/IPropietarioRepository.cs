using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IPropietarioRepository
{
    Task<IEnumerable<Propietario>> ListAsync();
    Task AddAsync(Propietario propietario);
    Task<Propietario> FindByIdAsync(int propietarioId);
    void Update(Propietario propietario);
    void Remove(Propietario propietario);
    Task<Propietario> FindByEmailAsync(string email);
}