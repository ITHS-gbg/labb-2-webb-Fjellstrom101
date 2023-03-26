using BagarBasse.Shared.DTOs.OrderDTOs;
using BagarBasse.Shared.Models;

namespace BagarBasse.OrderDataAccess.Repositories;

public interface IOrderRepository : IDisposable
{
    void Add(OrderDto obj);
    Task<OrderDto> GetById(Guid id);
    Task<IEnumerable<OrderDto>> GetAll();
    void Update(OrderDto obj);
    void Remove(Guid id);
}