using BagarBasse.OrderDataAccess.Context;
using BagarBasse.OrderDataAccess.UnitOfWork;
using BagarBasse.Shared.DTOs.OrderDTOs;
using MongoDB.Driver;

namespace BagarBasse.OrderDataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    public readonly IMongoContext OrderContext;
    public IMongoCollection<OrderDto> DbSet;

    public OrderRepository(IMongoContext orderContext)
    {
        OrderContext = orderContext;

        DbSet = OrderContext.GetCollection<OrderDto>("Orders");
    }

    public virtual void Add(OrderDto obj)
    {
        OrderContext.AddCommand(() => DbSet.InsertOneAsync(obj));
    }

    public virtual async Task<OrderDto> GetById(Guid id)
    {
        var data = await DbSet.FindAsync(Builders<OrderDto>.Filter.Eq("_id", id));
        return data.SingleOrDefault();
    }

    public virtual async Task<IEnumerable<OrderDto>> GetAll()
    {
        var all = await DbSet.FindAsync(Builders<OrderDto>.Filter.Empty);
        return all.ToEnumerable();
    }

    public virtual void Update(OrderDto obj)
    {
        OrderContext.AddCommand(() => DbSet.ReplaceOneAsync(Builders<OrderDto>.Filter.Eq("_id", obj.Id), obj));
    }

    public virtual void Remove(Guid id)
    {
        OrderContext.AddCommand(() => DbSet.DeleteOneAsync(Builders<OrderDto>.Filter.Eq("_id", id)));
    }

    public void Dispose()
    {
        OrderContext?.Dispose();
    }
}