﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BagarBasse.Shared.Models;

public class Order
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}