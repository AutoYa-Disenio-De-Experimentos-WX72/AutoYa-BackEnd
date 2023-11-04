namespace AutoYa_Backend.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}