using AutoYa_Backend.Security.Domain.Models;

namespace AutoYa_Backend.Security.Domain.Repositories;

/// <summary>
/// Interfaz que define los métodos para un repositorio de usuarios.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Obtiene una lista de todos los usuarios de forma asíncrona.
    /// </summary>
    Task<IEnumerable<User>> ListAsync();
    
    /// <summary>
    /// Añade un usuario de forma asíncrona.
    /// </summary>
    /// <param name="user">El usuario a añadir.</param>
    Task AddAsync(User user);
    
    /// <summary>
    /// Encuentra un usuario por su ID de forma asíncrona.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    Task<User> FindByIdAsync(int id);
    
    /// <summary>
    /// Encuentra un usuario por su correo electrónico de forma asíncrona.
    /// </summary>
    /// <param name="email">El correo electrónico del usuario.</param>
    Task<User> FindByEmailAsync(string email);
    
    /// <summary>
    /// Verifica si existe un usuario con el correo electrónico dado.
    /// </summary>
    /// <param name="email">El correo electrónico a verificar.</param>
    public bool ExistsByEmail(string email);
    
    /// <summary>
    /// Encuentra un usuario por su ID.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    User FindById(int id);
    
    /// <summary>
    /// Actualiza un usuario.
    /// </summary>
    /// <param name="user">El usuario a actualizar.</param>
    void Update(User user);
    
    /// <summary>
    /// Elimina un usuario.
    /// </summary>
    /// <param name="user">El usuario a eliminar.</param>
    void Remove(User user);
}