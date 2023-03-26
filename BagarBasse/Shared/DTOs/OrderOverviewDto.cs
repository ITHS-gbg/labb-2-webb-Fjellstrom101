﻿using MongoDB.Bson;

namespace BagarBasse.Shared.DTOs;

public class OrderOverviewDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Product { get; set; } = string.Empty;

    public string ProductImageUrl { get; set; } = string.Empty;
}