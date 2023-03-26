using BagarBasse.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BagarBasse.Shared.DTOs.OrderDTOs;

public class OrderDto
{
    [BsonId] public Guid Id { get; set; } = Guid.NewGuid();

    [BsonElement]
    public int UserId { get; set; }
    [BsonElement]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    [BsonElement]
    public decimal TotalPrice { get; set; }
    [BsonElement]
    public List<OrderItemDto> OrderItems { get; set; }
    [BsonElement]
    public UserDto User { get; set; }
}