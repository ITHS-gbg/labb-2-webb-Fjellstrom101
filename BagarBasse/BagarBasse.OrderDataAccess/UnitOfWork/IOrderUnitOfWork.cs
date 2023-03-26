namespace BagarBasse.OrderDataAccess.UnitOfWork;


public interface IOrderUnitOfWork : IDisposable
{
    Task<bool> SaveChangesAsync();
}
