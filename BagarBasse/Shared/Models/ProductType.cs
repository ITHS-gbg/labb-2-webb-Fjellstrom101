﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BagarBasse.Shared.Models;

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
    [NotMapped]
    public bool Editing { get; set; } = false;
    [NotMapped]
    public bool IsNew { get; set; } = false;
}