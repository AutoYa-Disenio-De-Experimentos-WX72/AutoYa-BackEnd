using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IArrendatarioRepository
{
    Task<IEnumerable<Arrendatario>> ListAsync();
    Task AddAsync(Arrendatario arrendatario);
    Task<Arrendatario> FindByIdAsync(int? arrendatarioId);
    Task<Arrendatario> FindByEmailAsync(string email);
    void Update(Arrendatario arrendatario);
    void Remove(Arrendatario arrendatario);
}