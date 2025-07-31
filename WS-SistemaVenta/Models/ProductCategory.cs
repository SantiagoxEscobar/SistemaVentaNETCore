using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
