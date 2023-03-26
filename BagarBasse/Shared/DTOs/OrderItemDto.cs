using MongoDB.Bson.Serialization.Attributes;

namespace BagarBasse.Shared.DTOs.OrderDTOs;

public class OrderItemDto
{
    [BsonElement]
    public int Id { get; set; }
    [BsonElement]
    public string Title { get; set; } = string.Empty;
    [BsonElement]
    public string Image { get; set; } = string.Empty;
    [BsonElement]
    public string ProductVariant { get; set; }
    [BsonElement]
    public decimal OriginalPrice { get; set; }
    [BsonElement]
    public decimal Price { get; set; }
    [BsonElement]
    public int Quantity { get; set; }
}