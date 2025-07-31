using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class Product
{
    public int Id { get; set; }

    public int IdCategory { get; set; }

    public int IdBrand { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal CurrentSalesPrice { get; set; }

    public decimal CostPrice { get; set; }

    public string? Sku { get; set; }

    public string? Barcode { get; set; }

    public int CurrentStock { get; set; }

    public int MinimumStock { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Brand IdBrandNavigation { get; set; } = null!;

    public virtual ProductCategory IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public virtual User? UpdatedByNavigation { get; set; }
}
