namespace BagarBasse.Server.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}