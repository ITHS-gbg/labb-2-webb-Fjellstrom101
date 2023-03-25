using BagarBasse.OrderDataAccess.UnitOfWork;
using BagarBasse.Shared.Models;
using MongoDB.Driver;

namespace BagarBasse.OrderDataAccess.Repositories;

public class OrderRepository : IOrderRepository
{

    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<ProductMongoEntity> _productsCollection;
    private readonly IUnitOfWork _unitOfWork;

    public IQueryable<Order> Get()
    {
        throw new NotImplementedException();
    }

    public Order GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Insert(Order order)
    {
        throw new NotImplementedException();
    }

    public void Update(Order order)
    {
        throw new NotImplementedException();
    }

    public void Remove(Guid id)
    {
        throw new NotImplementedException();
    }
}