using System;
using System.Collections.Generic;

namespace WSVenta.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string BrandName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
