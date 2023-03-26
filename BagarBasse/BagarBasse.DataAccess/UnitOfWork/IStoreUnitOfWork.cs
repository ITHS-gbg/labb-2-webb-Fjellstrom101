namespace BagarBasse.Server.UnitOfWork;

public interface IStoreUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}