using System;
using System.Collections.Generic;

namespace WSVenta.Models;

public partial class ProductImage
{
    public long Id { get; set; }

    public int IdProduct { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

    public bool IsMainImage { get; set; }

    public int? DisplayOrder { get; set; }

    public string? FileName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
