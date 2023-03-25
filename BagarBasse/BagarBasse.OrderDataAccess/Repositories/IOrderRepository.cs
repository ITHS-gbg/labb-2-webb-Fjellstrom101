using BagarBasse.Shared.Models;

namespace BagarBasse.OrderDataAccess.Repositories;

public interface IOrderRepository
{
    IQueryable<Order> Get();

    Order GetById(Guid id);

    void Insert(Order order);

    void Update(Order order);

    void Remove(Guid id);
}