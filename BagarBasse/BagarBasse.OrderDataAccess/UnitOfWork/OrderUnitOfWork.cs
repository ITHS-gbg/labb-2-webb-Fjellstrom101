using BagarBasse.OrderDataAccess.Context;
using BagarBasse.OrderDataAccess.Repositories;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;

namespace BagarBasse.OrderDataAccess.UnitOfWork;

public class OrderUnitOfWork : IOrderUnitOfWork
{
    private readonly IMongoContext _context;
    private OrderRepository? _orderRepository;
    public OrderRepository OrderRepository
    {
        get { return _orderRepository ??= new OrderRepository(_context); }
    }

    public OrderUnitOfWork(IMongoContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChangesAsync()
    {
        var changeAmount = await _context.SaveChanges();

        return changeAmount > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}