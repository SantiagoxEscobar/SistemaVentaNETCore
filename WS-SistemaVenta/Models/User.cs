using System;
using System.Collections.Generic;

namespace WS_SistemaVenta.Models;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Username { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual Client? Client { get; set; }

    public virtual UserRole IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
