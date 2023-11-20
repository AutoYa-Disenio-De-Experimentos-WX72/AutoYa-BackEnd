namespace AutoYa_Backend.Shared.Persistence.Repositories;

/// <summary>
/// Interfaz que define los métodos para una unidad de trabajo.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Completa la unidad de trabajo de forma asíncrona.
    /// </summary>
    Task CompleteAsync();
}